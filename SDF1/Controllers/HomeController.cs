using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SDF1.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        ViewData["ActivePage"] = "home";
        return View();
    }

}
