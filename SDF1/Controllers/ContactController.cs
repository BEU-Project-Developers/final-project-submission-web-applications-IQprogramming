using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "contact";
            return View();
        }
    }
}
