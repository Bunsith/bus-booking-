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
    public partial class frmpricereport : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmpricereport()
        {
            InitializeComponent();
        }

        private void frmpricereport_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("pricereport", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("id", id);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CrystalReport8 report1 = new CrystalReport8();
            report1.SetDataSource(dt);
            crystalReportViewer1.ReportSource = report1;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
