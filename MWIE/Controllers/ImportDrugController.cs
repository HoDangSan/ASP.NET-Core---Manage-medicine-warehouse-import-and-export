using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.DetailReceiptImportService;
using MWIE.Service.DrugService;
using MWIE.Service.GroupDrugService;
using MWIE.Service.ProducerService;
using MWIE.Service.ReceiptImportService;
using MWIE.Service.UserService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class ImportDrug : Controller
    {
        private readonly IDrugService _drugService;
        private readonly IGroupDrugService _groupDrugService;
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IReceiptImportService _receiptImportService;
        private readonly IDetailReceiptImportService _detailReceiptImportService;

        
        public ImportDrug(IDrugService drugService, IGroupDrugService groupDrugService, IProducerService producerService, IMapper mapper, IUserService userService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IReceiptImportService receiptImportService, IDetailReceiptImportService detailReceiptImportService)
        {
            _drugService = drugService;
            _groupDrugService = groupDrugService;
            _producerService = producerService;
            _mapper = mapper;
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
            _receiptImportService = receiptImportService;
            _detailReceiptImportService = detailReceiptImportService;
        }

        public IActionResult Index()
        {
            
            var model = new ImportDrugViewmodel();
            
            return
                View(model);
        }

        public IActionResult GetUser()
        {
            var userProfileId = User.Claims
                .Where(c => c.Type == "UserProfileId")
                .Select(c => c.Value).SingleOrDefault();

            UserProfile userProfile;

            if (userProfileId != null)
            {
                userProfile = _userService.GetById(Int32.Parse(userProfileId));
            }
            else
            {
                userProfile = _userService.GetById(1);
            }

            return Json(new { data = userProfile });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var receiptImports =  _receiptImportService.GetAll();
            Collection<ReceiptImportViewModel> model = new Collection<ReceiptImportViewModel>();
            foreach (var item in receiptImports)
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

                    ReceiptImportViewModel receiptImportViewModel = new ReceiptImportViewModel()
                    {
                        Id = item.Id,
                        CodeReceipt = item.CodeReceipt,
                        DateCreate = item.DateCreate,
                        TotalPrice = item.TotalPrice,
                        ProUserProfileName = nameUser,
                        IsActive = (item.IsActive) ? "Đang hoạt động" : "Đã khóa"
                    };

                    model.Add(receiptImportViewModel);
                }
            }
            return Json(model);
        }
        
        [HttpGet]
        public IActionResult GetDetails()
        {
            var model =  _detailReceiptImportService.GetAll();
            return Json(model);
        }

        [HttpPost]
        public IActionResult CreateReceiptImport([FromBody] ReceiptImport model)
        {
            _receiptImportService.Add(model);
            _receiptImportService.Save();
            return Json(new {data = model, message = "Đẫ thêm thành công!"});
        }
        
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            var detailReceiptImports =  _detailReceiptImportService.GetAll();
            Collection<DetailReceiptImportViewModel> model = new Collection<DetailReceiptImportViewModel>();
            
            foreach (var item in detailReceiptImports)
            {
                if (item.ReceiptImportId == id)
                {
                    Drug drug = _drugService.GetById(item.DrugId);
                    
                    DetailReceiptImportViewModel detailReceiptImportViewModel = new DetailReceiptImportViewModel()
                    {
                        Id = item.Id,
                        Amount = item.Amount,
                        TotalPrice =  item.TotalPrice,
                        DrugName = drug.Name,
                        ReceiptImportId = item.ReceiptImportId,
                        Price = drug.Price,
                        DateOfManufacture = drug.DateOfManufacture,
                        ExpriryDate = drug.ExpriryDate
                        
                    };
                    
                    model.Add(detailReceiptImportViewModel);
                }
            }
            
            return Json(new{data=model, message = "Thanh cong"});
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ReceiptImport receiptImport = _receiptImportService.GetById(id);
            receiptImport.IsActive = false;
            
            _receiptImportService.Update(receiptImport);
            _receiptImportService.Save();
            return Ok(new {message = "Xoa mem thanh cong"});
        }
        
    }
}