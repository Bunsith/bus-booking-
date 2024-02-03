using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Bus_bookig
{
   public abstract class DBconnection
    {
        private static OracleConnection conn;
        private readonly string connectionString;

        // static method
        public static OracleConnection connect()
        {
            try
            {
                conn = new OracleConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["StrConn"].ToString();
                //conn.Open();
                //MessageBox.Show("Connection to database is ok");
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Connection Errors...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
