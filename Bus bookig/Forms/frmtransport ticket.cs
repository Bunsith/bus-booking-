using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig.Forms
{
    public partial class frmtransportticket : Form
    {
        OracleConnection conn = DBconnection.connect();
        private static int id;
        

        public frmtransportticket(int orderid)
        {
            InitializeComponent();
            id = orderid;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("transport", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", id);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CrystalReport3 report1 = new CrystalReport3();
            report1.SetDataSource(dt);
            crystalReportViewer1.ReportSource = report1;
            crystalReportViewer1.Refresh();
        }
    }
}
