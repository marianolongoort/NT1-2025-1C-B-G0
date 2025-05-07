using EstacionamientoMVC.B.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamientoMVC.B.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index(int id)
        {
            Persona persona1 = new Persona() { 
                Id = id,
                Nombre = "Mariano",
                Apellido = "Longo"
            };


            return View(persona1);
        }
    }
}
