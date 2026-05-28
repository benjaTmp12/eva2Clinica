using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eva2Clinica.Models;

namespace eva2Clinica.Controllers
{
    [Authorize] // El candado de seguridad
    public class PacienteController : Controller
    {
        private readonly PacienteData _pacienteData;

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
            if (paciente == null || paciente.Id == 0) return NotFound();
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
            if (paciente == null || paciente.Id == 0) return NotFound();
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