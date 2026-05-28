using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eva2Clinica.Models;

namespace eva2Clinica.Controllers
{
    public class PacienteController : AuthenticatedController
    {
        private readonly PacienteData _pacienteData;

        public PacienteController(PacienteData pacienteData)
        {
            _pacienteData = pacienteData;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = _pacienteData.Listar();
            return View(lista);
        }
    }
}