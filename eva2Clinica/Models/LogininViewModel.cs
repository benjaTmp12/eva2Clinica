using System.ComponentModel.DataAnnotations;

namespace eva2Clinica.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese el usuario")]
        public string Usuario { get; set; } = "";

        [Required(ErrorMessage = "Ingrese la contraseña")]
        public string Clave { get; set; } = "";
    }
}