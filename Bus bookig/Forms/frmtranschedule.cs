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
    public partial class frmtranschedule : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmtranschedule()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addtransche", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vday", dateTimePicker1.Value);
                cmd.Parameters.Add("vtime", txttime.Text);
                cmd.Parameters.Add("vduration", txtduration.Text);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vbus", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriver", cbodriver.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtransch();
                showsource();
                showdest();
                clear();
                showbus();
                showdriver();
                MessageBox.Show("One Record has been Add.", "Record Added.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void showtransch()
        {
            OracleCommand cmd = new OracleCommand("showtransch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "transch");
            dataGridView1.DataSource = ds.Tables["transch"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txttransc.Clear();
            txttime.Clear();
            txtsearch.Clear();
            txtprice.Clear();
            txtduration.Clear();
        }
        private void showsource()
        {
            string sql_select = "SELECT brname FROM tblbranch";
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "branch");

            cbosource.DataSource = ds.Tables["branch"];
            cbosource.DisplayMember = "brname";
            cbosource.ValueMember = "brname";

            ds.Dispose();
            adapter.Dispose();
        }
        private void showdest()
        {
            string sql_select = "SELECT brname FROM tblbranch";
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "branch");

            cbodest.DataSource = ds.Tables["branch"];
            cbodest.DisplayMember = "brname";
            cbodest.ValueMember = "brname";

            ds.Dispose();
            adapter.Dispose();
        }
        private void showbus()
        {
            string sql_select = "SELECT busid FROM tblbus";
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "bus");

            cbobus.DataSource = ds.Tables["bus"];
            cbobus.DisplayMember = "busid";
            cbobus.ValueMember = "busid";

            ds.Dispose();
            adapter.Dispose();
        }
        private void showdriver()
        {
            string sql_select = "SELECT driverid,drivername FROM tbldriver";
            // create data adater object
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            // create dataset object
            DataSet ds = new DataSet();

            // fill data into dataset object: ds
            adapter.Fill(ds, "driver");

            cbodriver.DataSource = ds.Tables["driver"];
            cbodriver.DisplayMember = "drivername";
            cbodriver.ValueMember = "driverid";

            ds.Dispose();
            adapter.Dispose();
        }

        private void frmtranschedule_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showtransch();
            showsource();
            showdest();
            clear();
            showbus();
            showdriver();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatetransche", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranschid", txttransc.Text);
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vday", dateTimePicker1.Value);
                cmd.Parameters.Add("vtime", txttime.Text);
                cmd.Parameters.Add("vduration", txtduration.Text);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vbus", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriver", cbodriver.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtransch();
                showsource();
                showdest();
                clear();
                showbus();
                showdriver();
                MessageBox.Show("One Record has been Update.", "Record Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("deletetransch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranschid", txttransc.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtransch();
                showsource();
                showdest();
                clear();
                showbus();
                showdriver();
                MessageBox.Show("One Record has been Delete.", "Record Delete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txttransc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbosource.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbodest.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttime.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtduration.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbobus.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbodriver.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("searchtransch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vsource", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
            OracleDataAdapter adap = new OracleDataAdapter();
            adap.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.Dispose();
            adap.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            frmtransechdulereport sr = new frmtransechdulereport();
            sr.ShowDialog();
        }
    }
}
