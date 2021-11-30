using System.Configuration;

namespace Domain.Repositories.Connection
{
    public class ConnectionRepository
    {
        private readonly string connectionString;
        public ConnectionRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}