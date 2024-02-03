using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_bookig.Forms
{
    public partial class frmbranchreport : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmbranchreport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("branchreport", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("id", id);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CrystalReport6 report1 = new CrystalReport6();
            report1.SetDataSource(dt);
            crystalReportViewer1.ReportSource = report1;
            crystalReportViewer1.Refresh();
        }
    }
}
