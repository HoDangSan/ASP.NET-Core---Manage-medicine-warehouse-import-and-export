using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class StatisticalImportController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}