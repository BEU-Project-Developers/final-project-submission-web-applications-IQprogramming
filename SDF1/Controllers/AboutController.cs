using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "about";
            return View();
        }
    }
}
