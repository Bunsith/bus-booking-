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
    public partial class frmdriver : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmdriver()
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
            label7.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            


        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtname.Text))
            {
                MessageBox.Show("Please Enter Driver Name !", "Required Driver Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("adddriver", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vdrivername", txtname.Text);
                cmd.Parameters.Add("vgender", txtgender.Text);
                cmd.Parameters.Add("vdrivercardid", txtcardid.Text);
                cmd.Parameters.Add("vdriverlicenseid", txtlicenseid.Text);
                cmd.Parameters.Add("vdriverphoneno", txtphone.Text);
                cmd.Parameters.Add("vdriveraddress", txtaddress.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showdriver();
                showemployee();
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
        private void showdriver()
        {
            OracleCommand cmd = new OracleCommand("showdriver", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "driver");
            dataGridView1.DataSource = ds.Tables["driver"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txtaddress.Clear();
            txtcardid.Clear();
            txtsearch.Clear();
            txtphone.Clear();
            txtdriverid.Clear();
            txtname.Clear();
            txtgender.Clear();
            cboemployee.Text = string.Empty;
            txtlicenseid.Clear();
        }
        private void showemployee()
        {
            string sql_select = "SELECT empid, empname FROM tblemployee";
            // create data adater object
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            // create dataset object
            DataSet ds = new DataSet();

            // fill data into dataset object: ds
            adapter.Fill(ds, "employee");

            cboemployee.DataSource = ds.Tables["employee"];
            cboemployee.DisplayMember = "empname";
            cboemployee.ValueMember = "empid";

            ds.Dispose();
            adapter.Dispose();
        }

        private void frmdriver_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showemployee();
            clear();
            showdriver();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtdriverid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cboemployee.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtgender.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtcardid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtlicenseid.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtphone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatedriver", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vdriverid", txtdriverid.Text);
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vdrivername", txtname.Text);
                cmd.Parameters.Add("vgender", txtgender.Text);
                cmd.Parameters.Add("vdrivercardid", txtcardid.Text);
                cmd.Parameters.Add("vdriverlicenseid", txtlicenseid.Text);
                cmd.Parameters.Add("vdriverphoneno", txtphone.Text);
                cmd.Parameters.Add("vdriveraddress", txtaddress.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showdriver();
                showemployee();
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
                OracleCommand cmd = new OracleCommand("deletedriver", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vdriverid", Int32.Parse(txtdriverid.Text));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showemployee();
                clear();
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("searchdriver", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vdrivername", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
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
            frmdriverreport sr = new frmdriverreport();
            sr.ShowDialog();
        }
    }
}
