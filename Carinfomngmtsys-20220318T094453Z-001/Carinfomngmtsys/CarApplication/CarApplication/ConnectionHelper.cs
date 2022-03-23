using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarApplication
{
    public class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            string strcon = ConfigurationManager.ConnectionStrings["casestudyconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }
    }
}
