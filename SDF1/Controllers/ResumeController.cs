using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "resume";
            return View();
        }
    }
}
