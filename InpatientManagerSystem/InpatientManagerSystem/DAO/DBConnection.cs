using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
