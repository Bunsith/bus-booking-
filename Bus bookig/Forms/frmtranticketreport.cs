using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
namespace Bus_bookig.Forms
{
    public partial class frmtranticketreport : Form
    {
        OracleConnection conn = DBconnection.connect();
        SqlCommand cmd = new SqlCommand();
        private static int id;
        public frmtranticketreport(int orderid)
        {
            InitializeComponent();
            id = orderid;
        }

        private void frmtranticketreport_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand("test", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", id);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CrystalReport1 report1 = new CrystalReport1();
                report1.SetDataSource(dt);
                crystalReportViewer2.ReportSource = report1;
                crystalReportViewer2.Refresh();
            
        }
    }
}
