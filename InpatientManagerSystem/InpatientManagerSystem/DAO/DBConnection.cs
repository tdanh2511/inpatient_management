using MySql.Data.MySqlClient;
using System.Configuration;

namespace InpatientManagerSystem.DAO
{
    public class DBConnection
    {
        private string connectionString;
        public DBConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
