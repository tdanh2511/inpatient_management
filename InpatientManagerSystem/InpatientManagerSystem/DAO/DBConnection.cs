using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
