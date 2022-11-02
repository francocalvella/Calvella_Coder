namespace FCalvellaAPI.Models
{
    public class Producto
    {
        public Producto()
        {
            Id = 0;
            Descripcion = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public Producto(int id, double precioVenta, string descripcion, double costo, int stock, int idUsuario)
        {
            Id = id;
            PrecioVenta = precioVenta;
            Descripcion = descripcion;
            Costo = costo;
            Stock = stock;
            IdUsuario = idUsuario;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
