using Microsoft.AspNetCore.Mvc;
using eva2Clinica.Models;

namespace eva2Clinica.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            if (login.Usuario == "admin" && login.Clave == "1234")
            {
                HttpContext.Session.SetString("Usuario", login.Usuario);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View(login);
        }
    }
}