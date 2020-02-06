using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MWIE.Encryption;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.DrugService;
using MWIE.Service.GroupDrugService;
using MWIE.Service.ProducerService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;
        private readonly IGroupDrugService _groupDrugService;
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;
        
        public DrugController(IDrugService drugService, IGroupDrugService groupDrugService,IProducerService producerService , IMapper mapper)
        {
            _drugService = drugService;
            _groupDrugService = groupDrugService;
            _producerService = producerService;
            _mapper = mapper;
          
        }
        
       
        // GET
        [HttpGet]
        public ViewResult Index()
        {   
            var drugs = _drugService.GetAll();
            var model = _mapper.Map<IEnumerable<DrugViewModel>>(drugs);
            foreach (var i in model)
            {
                if (i.ProducerId != null) i.ProducerName = _producerService.GetById((int) i.ProducerId).Name;
                if (i.GroupDrugId != null) i.GroupDrugName = _groupDrugService.GetById((int) i.GroupDrugId).Name;
            }
            
            return
                View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<GroupDrug> groupDrugs = _groupDrugService.GetAll();
            IEnumerable<Producer> producers = _producerService.GetAll();
            ViewData["GroupDrugId"] = new SelectList(groupDrugs, "Id", "Name");
            ViewData["ProducerId"] = new SelectList(producers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(DrugViewModelEdit drugViewModelEdit)
        {
            var drug = _mapper.Map<Drug>(drugViewModelEdit);
            
            _drugService.Add(drug);
            _drugService.Save();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult SaveDrug([FromBody] Drug model)
        {
            _drugService.Add(model);
            _drugService.Save();
            
            return Json(new {data=model,message="Thêm thành công!"});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<GroupDrug> groupDrugs = _groupDrugService.GetAll();
            IEnumerable<Producer> producers = _producerService.GetAll();
            ViewData["GroupDrugId"] = new SelectList(groupDrugs, "Id", "Name");
            ViewData["ProducerId"] = new SelectList(producers, "Id", "Name");
            var drug = _drugService.GetById(id);
            var model = _mapper.Map<DrugViewModelEdit>(drug);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DrugViewModelEdit drugViewModelEdit)
        {
          
            var drug = _mapper.Map<Drug>(drugViewModelEdit);
            
            _drugService.Update(drug);
            _drugService.Save();
            return RedirectToAction("Index");
        }
        
        [HttpPut]
        public IActionResult EditDrug([FromBody] DrugViewModelEdit drugViewModelEdit)
        {
            var drug = _mapper.Map<Drug>(drugViewModelEdit);
            
            _drugService.Update(drug);
            _drugService.Save();

            return Json(new {data=drug, message="Bạn đã sửa thành công!!"});
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _drugService.Delete(id);
            _drugService.Save();
            return RedirectToAction("Index");
        }

        // GET: Drug/ListAll
        public JsonResult ListAll()
        {
            var drugs = _drugService.GetAll();
            Collection<Drug> drugsfillter = new Collection<Drug>();
            foreach (var item in drugs)
            {    
                if (item.IsActive)
                {
                    drugsfillter.Add(item);
                }
            }
            var model = _mapper.Map<IEnumerable<DrugViewModel>>(drugsfillter);
            var drugViewModels = model as DrugViewModel[] ?? model.ToArray();
            foreach (var i in drugViewModels)
            {
                if (i.ProducerId != null) i.ProducerName = _producerService.GetById((int) i.ProducerId).Name;
                if (i.GroupDrugId != null) i.GroupDrugName = _groupDrugService.GetById((int) i.GroupDrugId).Name;
            }
            
            return Json(new{data = drugViewModels});
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Drug drug = _drugService.GetById(id);

            return Json(new{data=drug});
        }

        [HttpDelete]
        public IActionResult DeleteDrug(int id)
        {
            _drugService.Delete(id);
            _drugService.Save();
            return Ok(new {message = "Xoa thanh cong"});
        }
    }
}