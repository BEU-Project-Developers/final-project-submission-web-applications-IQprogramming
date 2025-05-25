using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "portfolio";
            return View();
        }
    }
}
