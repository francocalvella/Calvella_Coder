using System.Data;
using FCalvellaAPI.Models;
using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> TraerVentasPorUserId()
        {
            using (SqlConnection connection = new SqlConnection(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                List<Venta> ventasUser = new List<Venta>();
                cmd.CommandText = "SELECT * FROM Venta";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["id"]);
                    var comentario = reader["Comentarios"].ToString();
                    var idUsuario = Convert.ToInt32(reader["idUsuario"]);
                    var venta = new Venta(id, comentario, idUsuario);

                    ventasUser.Add(venta);
                }
                connection.Close();
                return ventasUser;
            }

        }
        public static void AgregarVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(General.GetConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Venta (comentarios, IdUsuario) VALUES (@commentParam, @idUserParam)";

                SqlParameter commentParam = new("commentParam", SqlDbType.VarChar) { Value = venta.Comentario };
                SqlParameter idUserParam = new("idUserParam", SqlDbType.VarChar) { Value = venta.IdUsuario };

                cmd.Parameters.Add(idUserParam);
                cmd.Parameters.Add(commentParam);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public static void EliminarVenta(int id)
        {
            using (SqlConnection conn = new(General.GetConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Venta WHERE Id = @idParam";

                SqlParameter idParam = new("idParam", SqlDbType.BigInt) { Value = id };
                cmd.Parameters.Add(idParam);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
