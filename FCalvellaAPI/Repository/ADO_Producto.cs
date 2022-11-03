using FCalvellaAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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
        public static void AgregarProducto(Producto prod)
        {
            using(SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) "
                                + "VALUES (@descParam, @costoParam, @precVentaParam, @stockParam, @idUserParam)";

                SqlParameter descParam = new("descParam", SqlDbType.VarChar) { Value = prod.Descripcion };
                SqlParameter costoParam = new("costoParam", SqlDbType.BigInt) { Value = prod.Costo };
                SqlParameter precVentaParam = new("precVentaParam", SqlDbType.BigInt) { Value = prod.PrecioVenta};
                SqlParameter stockParam = new("stockParam", SqlDbType.BigInt) { Value = prod.Stock };
                SqlParameter idUserParam = new("idUserParam", SqlDbType.BigInt) { Value = prod.IdUsuario };
                cmd.Parameters.Add(descParam);  
                cmd.Parameters.Add(costoParam);
                cmd.Parameters.Add(precVentaParam);
                cmd.Parameters.Add(stockParam);
                cmd.Parameters.Add(idUserParam);

                cmd.ExecuteNonQuery();
            }
        }
        public static void EditarProducto(Producto prod)
        {
            using(SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Producto SET Descripciones = @descParam, Costo = @costoParam, "
                    + "PrecioVenta = @precVentaParam, Stock = @stockParam, IdUsuario = @idUserParam "
                    +"WHERE Id = @idParam";

                SqlParameter idParam = new("idParam ", SqlDbType.VarChar) { Value = prod.Id};
                SqlParameter descParam = new("descParam", SqlDbType.VarChar) { Value = prod.Descripcion };
                SqlParameter costoParam = new("costoParam", SqlDbType.BigInt) { Value = prod.Costo };
                SqlParameter precVentaParam = new("precVentaParam", SqlDbType.BigInt) { Value = prod.PrecioVenta };
                SqlParameter stockParam = new("stockParam", SqlDbType.BigInt) { Value = prod.Stock };
                SqlParameter idUserParam = new("idUserParam", SqlDbType.BigInt) { Value = prod.IdUsuario };
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(descParam);
                cmd.Parameters.Add(costoParam);
                cmd.Parameters.Add(precVentaParam);
                cmd.Parameters.Add(stockParam);
                cmd.Parameters.Add(idUserParam);

                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void BorrarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE from Producto WHERE Id = @idParam";

                SqlParameter idParam = new("idParam", SqlDbType.BigInt) { Value=id };
                cmd.Parameters.Add(idParam);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
