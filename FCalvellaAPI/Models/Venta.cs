namespace FCalvellaAPI.Models
{
    public class Venta
    {
        public Venta(int id, string comentario, int idUsuario)
        {
            Id = id;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }
        public Venta()
        {
            Id = 0;
            Comentario = string.Empty;
            IdUsuario = 0;
        }

        public int Id { get; set; }
        public string Comentario { get; set; }
        public int IdUsuario { get; set; }
    }
}
