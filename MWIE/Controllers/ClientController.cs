using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.ClientService;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Client/ListAll
        [HttpGet]
        public JsonResult ListAll()
        {
            var client = _clientService.GetAll();

            return Json(new { data = client });
        }

        // GET: Client/Get/{id}
        [HttpGet]
        public IActionResult Get(int id)
        {
            Client client = _clientService.GetById(id);

            return Json(new { data = client });
        }

        // POST: Client/Add
        [HttpPost]
        public IActionResult Add([FromBody] ClientViewModelEdit clientViewModelEdit)
        {
            var client = _mapper.Map<Client>(clientViewModelEdit);

            _clientService.Add(client);
            _clientService.Save();

            return Json(new { data = client, message = "Thêm thành công!" });
        }

        // PUT: Client/Edit
        [HttpPut]
        public IActionResult Edit([FromBody] ClientViewModelEdit clientViewModelEdit)
        {
            var client = _mapper.Map<Client>(clientViewModelEdit);

            _clientService.Update(client);
            _clientService.Save();

            return Json(new { data = client, message = "Bạn đã sửa thành công!!" });
        }

        // DELETE: Client/Delete/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            _clientService.Save();

            return Ok(new { message = "Xoa thanh cong" });
        }
    }
}