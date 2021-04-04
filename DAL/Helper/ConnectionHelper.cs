using Microsoft.Extensions.Configuration;

namespace DAL.Helper
{
    public class ConnectionHelper
    {
        public string connectionString;
        public ConnectionHelper(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
