using System.Data;
using FCalvellaAPI.Models;
using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Repository
{
    public class ADO_Usuario
    {
        public static IEnumerable<Usuario> TraerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["id"]);
                    string Nombre = reader["Nombre"].ToString();
                    string Apellido = reader["Apellido"].ToString();
                    string NombreUsuario = reader["NombreUsuario"].ToString();
                    string Password = reader["Contraseña"].ToString();
                    string Mail = reader["Mail"].ToString();
                    
                    Usuario user = new Usuario(Id, Nombre, Apellido, NombreUsuario, Password, Mail);
                    usuarios.Add(user);
                }
                connection.Close();
                return usuarios;
            }

        }
        public static Usuario Login(Usuario usuario)
        {
            using (SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                SqlParameter usernameParam = new("usernameParam", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter passwordParam = new("passwordParam", SqlDbType.VarChar) { Value = usuario.Password };
                cmd.Parameters.Add(usernameParam);
                cmd.Parameters.Add(passwordParam);

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @usernameParam"
                    + " AND Contraseña = @passwordParam";
                var reader = cmd.ExecuteReader();
                Usuario user = new Usuario();
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.Nombre = reader["Nombre"].ToString();
                    user.Apellido = reader["Apellido"].ToString();
                    user.NombreUsuario = reader["NombreUsuario"].ToString();
                    user.Password = reader["Contraseña"].ToString();
                    user.Mail = reader["Mail"].ToString();
                }
                if (user.Id == 0)
                {
                    Console.WriteLine("Usuario o contraseña incorrecta");
                }
                return user;

            }
        }
        public static void CrearUsuario(Usuario usuario)
        {
            using(SqlConnection connection = new(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                                    "VALUES (@paramNombre, @paramApellido, @paramNombreUsuario, @paramPassword, @paramMail)";
                var paramNombre = new SqlParameter("paramNombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                var paramApellido = new SqlParameter("paramApellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                var paramNombreUsuario = new SqlParameter("paramNombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                var paramPassword = new SqlParameter("paramPassword", SqlDbType.VarChar) { Value = usuario.Password };
                var paramMail = new SqlParameter("paramMail", SqlDbType.VarChar) { Value = usuario.Mail };

                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramMail);
                cmd.Parameters.Add(paramNombreUsuario);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void BorrarUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE from Usuario WHERE Id = @idParam";

                SqlParameter idParam = new("idParam", SqlDbType.BigInt) { Value = id };
                cmd.Parameters.Add(idParam);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
