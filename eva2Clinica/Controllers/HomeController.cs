using Microsoft.AspNetCore.Mvc;

namespace eva2Clinica.Controllers
{
    public class HomeController : Controller
    {
        // 1. PÁGINA DE INICIO 
        public IActionResult Index()
        {
            return View();
        }

        // 2. PÁGINA DE ESPECIALIDADES 
        public IActionResult Especialidades()
        {
            return View();
        }

        // 3. PÁGINA DE CONTACTO 
        public IActionResult Contacto()
        {
            return View();
        }
    }
}