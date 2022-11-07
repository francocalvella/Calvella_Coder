namespace FCalvellaAPI.Models
{
    public class Usuario
    {
        public Usuario(int id, string nombre, string apellido,
                        string nombreUsuario, string password, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Mail = mail;
            NombreUsuario = nombreUsuario;
        }
        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            Mail = string.Empty;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
