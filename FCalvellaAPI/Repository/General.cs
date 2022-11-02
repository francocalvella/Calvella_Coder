using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Repository
{
    public class General
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionBuilder = new();
            connectionBuilder.DataSource = "LENOVO-D35K3DAR\\SQLEXPRESS";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;
            connectionBuilder.Encrypt = false;
            var cs = connectionBuilder.ConnectionString;
            return cs;
        }
    }
}
