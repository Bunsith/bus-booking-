using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace Bus_bookig.Forms
{
    public partial class frmtranticket : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmtranticket()
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
            label11.ForeColor = ThemeColor.PrimaryColor;

        }
        private void frmtranticket_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showtranticket();
            showemp();
            showbus();
            showdriver();
            showsource();
            showdest();
            clear();
            dataGridView1.ClearSelection();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addtranticket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vdatetime", dateTimePicker2.Value);
                cmd.Parameters.Add("vseatno", txtseatno.Text);
                cmd.Parameters.Add("vcus", txtcusname.Text);
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vprice",txtprice.Text);
                cmd.Parameters.Add("vbus", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriver", cbodriver.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranticket();
                showemp();
                showbus();
                showdriver();
                showsource();
                showdest();
                clear();
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
        private void showtranticket()
        {
            OracleCommand cmd = new OracleCommand("showtranticket", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tranticket");
            dataGridView1.DataSource = ds.Tables["tranticket"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txttranid.Clear();
            txtcusname.Clear();
            txtprice.Clear();
            txtsearch.Clear();
            txtseatno.Clear();
        }
        private void showemp()
        {
            string sql_select = "SELECT empid,empname FROM tblemployee";
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "employee");

            cboemployee.DataSource = ds.Tables["employee"];
            cboemployee.DisplayMember = "empname";
            cboemployee.ValueMember = "empid";

            ds.Dispose();
            adapter.Dispose();
        }
        private void showbus()
        {
            string sql_select = "SELECT busid FROM tblbus";
            // create data adater object
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            // create dataset object
            DataSet ds = new DataSet();

            // fill data into dataset object: ds
            adapter.Fill(ds, "bus");

            cbobus.DataSource = ds.Tables["bus"];
            cbobus.DisplayMember = "bus";
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatetranticket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranticketid",Convert.ToInt32( txttranid.Text));
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vdatetime", dateTimePicker2.Value);
                cmd.Parameters.Add("vseatno", txtseatno.Text);
                cmd.Parameters.Add("vcus", txtcusname.Text);
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vbus", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriver", cbodriver.SelectedValue);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranticket();
                showemp();
                showbus();
                showdriver();
                showsource();
                showdest();
                clear();
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
                OracleCommand cmd = new OracleCommand("deletetranticket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranticketid", txttranid.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranticket();
                showemp();
                showbus();
                showdriver();
                showsource();
                showdest();
                clear();
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("searchticket", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vcus", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txttranid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbosource.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbodest.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtseatno.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtcusname.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cboemployee.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbobus.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cbodriver.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            
          int  orderid = Convert.ToInt32(txttranid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frmtranticketreport sr = new frmtranticketreport(orderid);
            sr.ShowDialog();

        }
    }
}
