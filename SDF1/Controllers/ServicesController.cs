using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "services";
            return View();
        }
    }
}
