using Microsoft.AspNetCore.Mvc;

namespace eva2Clinica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Especialidades()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }
    }
}