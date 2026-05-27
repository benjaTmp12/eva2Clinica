using Microsoft.AspNetCore.Mvc;
using eva2Clinica.Models;

namespace eva2Clinica.Controllers
{
    public class PacienteController : AuthenticatedController
    {
        private readonly PacienteData _pacienteData;

        // El constructor recibe la conexión a los datos
        public PacienteController(PacienteData pacienteData)
        {
            _pacienteData = pacienteData;
        }

        public IActionResult Index()
        {
            var lista = _pacienteData.Listar();
            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            if (ModelState.IsValid) 
            {
                _pacienteData.Crear(paciente);
                return RedirectToAction("Index"); 
            }
            return View(paciente); 
        }

        public IActionResult Editar(int id)
        {
            var paciente = _pacienteData.ObtenerPorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteData.Editar(paciente);
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public IActionResult Eliminar(int id)
        {
            var paciente = _pacienteData.ObtenerPorId(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Eliminar(Paciente paciente)
        {
            _pacienteData.Eliminar(paciente.Id);
            return RedirectToAction("Index");
        }
    }
}