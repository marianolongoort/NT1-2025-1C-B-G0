using EstacionamientoMVC.B.Data;
using EstacionamientoMVC.B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstacionamientoMVC.B.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiDb_B _context
            ;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Persona> _signInManager;

        public AccountController(
            MiDb_B context,
            UserManager<Persona> userManager,
            RoleManager<Rol> roleManager,
            SignInManager<Persona> signInManager
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }




        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login model)
        {
            if (ModelState.IsValid)
            {
                //sigo procesando 
                var resultado = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.Recordarme,false);

                if (resultado.Succeeded)
                {
                    //segui con lo que corresponda
                    return RedirectToAction("Index","Clientes");
                }

            }
            //hay error

            ModelState.AddModelError(string.Empty,"La combineta de User y Pass no va");

            return View(model);
        }


        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Registrar model)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                {
                    UserName = model.UserName,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Email = model.Email
                };

                var resultado = await _userManager.CreateAsync(cliente, model.Password);

                if (resultado.Succeeded)
                {
                    //agregare el o los roles que considere
                    //await _userManager.AddToRoleAsync(cliente,"ClienteRol");
                    //await _signInManager.SignInAsync(cliente,false);

                    return RedirectToAction("Index", "Clientes");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(model);
        }

    }
}
