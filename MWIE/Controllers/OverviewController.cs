using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}