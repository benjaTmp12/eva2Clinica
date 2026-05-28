namespace eva2Clinica.Models
{
    public class LoginViewModel
    {
        // El signo de interrogación ? le dice que acepte valores nulos sin tirar error
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
    }
}