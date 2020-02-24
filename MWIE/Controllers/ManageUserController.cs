using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MWIE.Encryption;
using MWIE.Models.Entity;
using MWIE.Models.ViewModel;
using MWIE.Service.UserService;

namespace MWIE.Controllers
{   
    public class ManageUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        //private readonly UserManager<IdentityUser> _userManager;

        public ManageUserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public ViewResult Index()
        {   
            var users = _userService.GetAll();
            var model = _mapper.Map<IEnumerable<UserProfileViewModel>>(users);
            
            return
                View(model);
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserProfileViewModel userViewModel)
        {
            
            var user = _mapper.Map<UserProfile>(userViewModel);
            
            _userService.Add(user);
            _userService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Policy = "Manager")]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            
            var userProfileId = User.Claims
                .Where(c => c.Type == "UserProfileId")
                .Select(c => c.Value).SingleOrDefault();
            
            if (id == Int32.Parse(userProfileId))
            {
                var model = _mapper.Map<UserProfileViewModelEdit>(user);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UserProfileViewModelEdit userViewModelEdit)
        {
            var user = _mapper.Map<UserProfile>(userViewModelEdit);
            
            _userService.Update(user);
            _userService.Save();
            return RedirectToAction("Edit");
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            _userService.Save();
            return RedirectToAction("Index");
        }

        // GET:  ManageUser/GetUser
        [Authorize(Policy = "Manager")]
        public JsonResult GetUser()
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
        [Authorize(Policy = "Manager")]
        public JsonResult Get(int id)
        {
            var user = _userService.GetById(id);

            return Json(new { data = user });
        }
    }
}