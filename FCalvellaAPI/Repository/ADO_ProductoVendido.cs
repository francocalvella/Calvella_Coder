using FCalvellaAPI.Models;
using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> TraerProductosVendidos()
        {
            using(SqlConnection conn = new(General.GetConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProductoVendido";
                List<ProductoVendido> productoVendidos = new List<ProductoVendido>();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)Convert.ToInt64(reader["id"]);
                    int stock = (int)Convert.ToInt64(reader["stock"]);
                    int idProducto = (int)Convert.ToInt64(reader["idProducto"]);
                    int idVenta = (int)Convert.ToInt64(reader["idVenta"]);

                    ProductoVendido prodVend = new(id, stock, idProducto, idVenta);
                    productoVendidos.Add(prodVend);
                }
                return productoVendidos;
            }
        }
    }
}
