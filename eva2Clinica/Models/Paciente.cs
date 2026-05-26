using System.ComponentModel.DataAnnotations;

namespace eva2Clinica.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El RUT es obligatorio")]
        [Display(Name = "RUT / Identificación")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 150, ErrorMessage = "Ingrese una edad válida")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electronico válido")]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El motivo de consulta es obligatorio")]
        [Display(Name = "Diagnostico / Motivo de Consulta")]
        public string Diagnostico { get; set; }
        public Paciente()
        {
            NombreCompleto = string.Empty;
            Rut = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
            Diagnostico = string.Empty;
        }
        public Paciente(int id, string nombreCompleto, string rut, int edad, string telefono, string direccion, string correo, string diagnostico)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Rut = rut;
            Edad = edad;
            Telefono = telefono;
            Direccion = direccion;
            Correo = correo;
            Diagnostico = diagnostico;
        }
    }
}