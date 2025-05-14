using System.Diagnostics;
using EstacionamientoMVC.B.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamientoMVC.B.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
