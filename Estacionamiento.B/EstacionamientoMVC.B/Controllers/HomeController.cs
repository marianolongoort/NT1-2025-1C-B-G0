using System.Diagnostics;
using EstacionamientoMVC.B.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstacionamientoMVC.B.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index(string nombre = "Sin definir",bool index2=false)
        {
            ViewResult resultado;

            if (index2)
            {
                resultado = View("Index2");
            }
            else
            {
                resultado = View();
            }

            return resultado;
        }

        public IActionResult Index2()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
