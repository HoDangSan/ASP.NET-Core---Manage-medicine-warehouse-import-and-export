using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.GroupDrugService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class GroupDrugController : Controller
    {
        private readonly IGroupDrugService _groupDrugService;
        private readonly IMapper _mapper;

        public GroupDrugController(IGroupDrugService groupDrugService, IMapper mapper)
        {
            _groupDrugService = groupDrugService;
            _mapper = mapper;
        }
        
        // GET
        [HttpGet]
        public ViewResult Index()
        {    
            
            var groupDrugs = _groupDrugService.GetAll();
            var model = _mapper.Map<IEnumerable<GroupDrugViewModel>>(groupDrugs);
            
            return
                View(model);
        }
        
        // GET
        [HttpGet]
        public IActionResult GetGroupDrugs()
        {    
            
            var groupDrugs = _groupDrugService.GetAll();
            var model = _mapper.Map<IEnumerable<GroupDrugViewModel>>(groupDrugs);

            return Json(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupDrugViewModelEdit groupDrugViewModelEdit)
        {
            var groupDrug = _mapper.Map<GroupDrug>(groupDrugViewModelEdit);
            
            _groupDrugService.Add(groupDrug);
            _groupDrugService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var groupDrug = _groupDrugService.GetById(id);
            var model = _mapper.Map<GroupDrugViewModelEdit>(groupDrug);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GroupDrugViewModelEdit groupDrugViewModelEdit)
        {
            var groupDrug = _mapper.Map<GroupDrug>(groupDrugViewModelEdit);
            
            _groupDrugService.Update(groupDrug);
            _groupDrugService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _groupDrugService.Delete(id);
            _groupDrugService.Save();
            return RedirectToAction("Index");
        }
    }
}