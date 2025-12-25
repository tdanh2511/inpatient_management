<<<<<<< HEAD
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9

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
