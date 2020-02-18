using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.DetailReceiptLiquidationService;
using MWIE.Service.DrugService;
using MWIE.Service.ReceiptLiquidationService;
using MWIE.Service.UserService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class LiquidationController : Controller
    {
        private readonly IReceiptLiquidationService _receiptLiquidationService;
        private readonly IDetailReceiptLiquidationService _detailReceiptLiquidationService;
        private readonly IDrugService _drugService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public LiquidationController(IReceiptLiquidationService receiptLiquidationService, IDetailReceiptLiquidationService detailReceiptLiquidationService, IMapper mapper, IDrugService drugService, IUserService userService)
        {
            _receiptLiquidationService = receiptLiquidationService;
            _detailReceiptLiquidationService = detailReceiptLiquidationService;
            _mapper = mapper;
            _drugService = drugService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            
            var model = new ImportDrugViewmodel();
            
            return
                View(model);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var receiptLiquidations =  _receiptLiquidationService.GetAll();
            Collection<ReceiptLiquidationViewModel> model = new Collection<ReceiptLiquidationViewModel>();
            
            foreach (var item in receiptLiquidations)
            {    
                if (item.IsActive)
                {
                    var user = _userService.GetById(item.Id);

                    string nameUser;

                    if (user != null)
                    {
                        nameUser = user.FirstName + user.LastName;
                    }
                    else nameUser = "";

                    ReceiptLiquidationViewModel receiptLiquidationViewModel = new ReceiptLiquidationViewModel()
                    {
                        Id = item.Id,
                        CodeReceipt = item.CodeReceipt,
                        DateCreate = item.DateCreate,
                        TotalPrice = item.TotalPrice,
                        ProUserProfileName = nameUser,
                        IsActive = (item.IsActive) ? "Đang hoạt động" : "Đã khóa"
                    };

                    model.Add(receiptLiquidationViewModel);
                }
            }
            return Json(model);
        }
        
        [HttpGet]
        public IActionResult GetDetails()
        {
            var model =  _detailReceiptLiquidationService.GetAll();
            return Json(model);
        }
        
        [HttpPost]
        public IActionResult CreateReceiptLiquidation([FromBody] ReceiptLiquidation model)
        {
            _receiptLiquidationService.Add(model);
            _receiptLiquidationService.Save();
            return Json(new {data = model, message = "Đẫ thêm thành công!"});
        }
        
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            var detailReceiptLiquidations =  _detailReceiptLiquidationService.GetAll();
            Collection<DetailReceiptLiquidationViewModel> model = new Collection<DetailReceiptLiquidationViewModel>();
            
            foreach (var item in detailReceiptLiquidations)
            {
                if (item.ReceiptLiquidationId == id)
                {
                    Drug drug = _drugService.GetById(item.DrugId);
                    
                    DetailReceiptLiquidationViewModel detailReceiptLiquidationViewModel = new DetailReceiptLiquidationViewModel()
                    {
                        Id = item.Id,
                        Amount = item.Amount,
                        TotalPrice =  item.TotalPrice,
                        DrugName = drug.Name,
                        ReceiptLiquidationId = item.ReceiptLiquidationId,
                        Price = drug.Price,
                        DateOfManufacture = drug.DateOfManufacture,
                        ExpriryDate = drug.ExpriryDate
                    };
                    
                    model.Add(detailReceiptLiquidationViewModel);
                }
            }
            
            return Json(new{data=model, message = "Thanh cong"});
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ReceiptLiquidation receiptLiquidation = _receiptLiquidationService.GetById(id);
            receiptLiquidation.IsActive = false;
            
            _receiptLiquidationService.Update(receiptLiquidation);
            _receiptLiquidationService.Save();
            return Ok(new {message = "Xoa mem thanh cong"});
        }
    }
}