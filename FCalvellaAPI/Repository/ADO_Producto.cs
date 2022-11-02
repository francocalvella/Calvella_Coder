using FCalvellaAPI.Models;
using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Repository
{

    public class ADO_Producto
    {
        public static List<Producto> TraerProductos()
        {
           var listaProductos = new List<Producto>();

            using (SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Producto();

                    product.Id = Convert.ToInt32(reader["id"]);
                    product.PrecioVenta = Convert.ToInt32(reader["PrecioVenta"]);
                    product.Descripcion = reader["Descripciones"].ToString();
                    product.Costo = Convert.ToInt32(reader["Costo"]);
                    product.Stock = Convert.ToInt32(reader["Stock"]);
                    product.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    listaProductos.Add(product);
                }
                connection.Close();
                return listaProductos;
            }
        }
    }
}
