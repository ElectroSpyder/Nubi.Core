namespace Nubi.Core.Application.DTO
{
    public class UserDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NombreCompleto {
            get
            {
                return Nombre + " "+ Apellido;
            }
        }
    }
}
