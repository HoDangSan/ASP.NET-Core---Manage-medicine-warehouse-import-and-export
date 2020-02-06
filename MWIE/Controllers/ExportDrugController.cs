using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.DetailReceiptExportService;
using MWIE.Service.DrugService;
using MWIE.Service.ReceiptExportService;

namespace MWIE.Controllers
{
    //[Authorize(Policy = "Manager")]
    public class ExportDrugController : Controller
    {
        private readonly IReceiptExportService _receiptExportService;
        private readonly IDetailReceiptExportService _detailReceiptExportService;
        private readonly IDrugService _drugService;
        private readonly IMapper _mapper;

        public ExportDrugController(IReceiptExportService receiptExportService, IDetailReceiptExportService detailReceiptExportService, IMapper mapper, IDrugService drugService)
        {
            _receiptExportService = receiptExportService;
            _detailReceiptExportService = detailReceiptExportService;
            _mapper = mapper;
            _drugService = drugService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var receiptExports =  _receiptExportService.GetAll();
            Collection<ReceiptExport> model = new Collection<ReceiptExport>();
            foreach (var item in receiptExports)
            {    
                if (item.IsActive)
                {
                    model.Add(item);
                }
            }
            return Json(model);
        }
        
        [HttpGet]
        public IActionResult GetDetails()
        {
            var model =  _detailReceiptExportService.GetAll();
            return Json(model);
        }
        
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            var detailReceiptExports =  _detailReceiptExportService.GetAll();
            Collection<DetailReceiptExportViewModel> model = new Collection<DetailReceiptExportViewModel>();
            foreach (var item in detailReceiptExports)
            {
                if (item.ReceiptExportId == id)
                {
                    Drug drug = _drugService.GetById(item.DrugId);
                    
                    DetailReceiptExportViewModel detailReceiptExportViewModel = new DetailReceiptExportViewModel()
                    {
                        Id = item.Id,
                        Amount = item.Amount,
                        AmountRemaining =  item.AmountRemaining,
                        TotalPrice =  item.TotalPrice,
                        DrugName = drug.Name,
                        ReceiptExportId = item.ReceiptExportId,
                        Price = drug.Price,
                        DateOfManufacture = drug.DateOfManufacture,
                        ExpriryDate = drug.ExpriryDate
                        
                    };
                    
                    model.Add(detailReceiptExportViewModel);
                }
            }
            
            return Json(new{data=model, message = "Thanh cong"});
        }
        
        [HttpPost]
        public IActionResult CreateReceiptExport([FromBody] ReceiptExport model)
        {
            //var model = _mapper.Map<ReceiptExport>(receiptExportCreate);
            
            _receiptExportService.Add(model);
            _receiptExportService.Save();
            return Json(new {data = model, message = "Đẫ thêm thành công!"});
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ReceiptExport receiptExport = _receiptExportService.GetById(id);
            receiptExport.IsActive = false;
            
            _receiptExportService.Update(receiptExport);
            _receiptExportService.Save();
            return Ok(new {message = "Xoa mem thanh cong"});
        }
    }
}