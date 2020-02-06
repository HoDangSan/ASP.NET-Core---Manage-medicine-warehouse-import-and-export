using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.ProducerService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;

        public ProducerController(IProducerService producerService, IMapper mapper)
        {
            _producerService = producerService;
            _mapper = mapper;
        }
        
        // GET
        [HttpGet]
        public ViewResult Index()
        {    
            
            var producs = _producerService.GetAll();
            var model = _mapper.Map<IEnumerable<ProducerViewModel>>(producs);
            
            return
                View(model);
        }

        // GET
        [HttpGet]
        public IActionResult GetProducers()
        {    
            
            var producs = _producerService.GetAll();
            var model = _mapper.Map<IEnumerable<ProducerViewModel>>(producs);

            return Json(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProducerViewModelEdit producerViewModelEdit)
        {
            var producer = _mapper.Map<Producer>(producerViewModelEdit);
            
            _producerService.Add(producer);
            _producerService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var producer = _producerService.GetById(id);
            var model = _mapper.Map<ProducerViewModelEdit>(producer);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProducerViewModelEdit producerViewModelEdit)
        {
            var producer = _mapper.Map<Producer>(producerViewModelEdit);
            
            _producerService.Update(producer);
            _producerService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            _producerService.Save();
            return RedirectToAction("Index");
        }
    }
}