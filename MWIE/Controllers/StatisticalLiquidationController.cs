using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MWIE.Controllers
{
    [Authorize(Policy = "Manager")]
    public class StatisticalLiquidationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}