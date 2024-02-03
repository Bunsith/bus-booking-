using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig.Forms
{
    public partial class frmbranch : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmbranch()
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
            label9.ForeColor = ThemeColor.PrimaryColor;
        }

        private void frmbranch_Load(object sender, EventArgs e)
        {
            showbranch();
            clear();
            dataGridView1.ClearSelection();
            LoadTheme();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtbranchname.Text))
            {
                MessageBox.Show("Please Enter Branch Name !", "Required Branch Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbranchname.Focus();
                return;
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addbranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbrname", txtbranchname.Text);
                cmd.Parameters.Add("vbrphone1", txtphone1.Text);
                cmd.Parameters.Add("vbrphone2", txtphone2.Text);
                cmd.Parameters.Add("vbrphone3", txtphone3.Text);
                cmd.Parameters.Add("vbrfax", txtfax.Text);
                cmd.Parameters.Add("vbraddress", txtaddress.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbranch();
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
        private void showbranch()
        {
            OracleCommand cmd = new OracleCommand("showbranch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "branch");
            dataGridView1.DataSource = ds.Tables["branch"];
            ds.Dispose();
            adapter.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txtbranchid.Clear();
            txtbranchname.Clear();
            txtphone1.Clear();
            txtphone2.Clear();
            txtphone3.Clear();
            txtaddress.Clear();
            txtfax.Clear();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtbranchid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtbranchname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtphone1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtphone2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtphone3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtfax.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatebranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbrid", Int32.Parse(txtbranchid.Text));
                cmd.Parameters.Add("vbrname", txtbranchname.Text);
                cmd.Parameters.Add("vbrphone1", txtphone1.Text);
                cmd.Parameters.Add("vbrphone2", txtphone2.Text);
                cmd.Parameters.Add("vbrphone3", txtphone3.Text);
                cmd.Parameters.Add("vbrfax", txtfax.Text);
                cmd.Parameters.Add("vbraddress", txtaddress.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbranch();
                clear();
                MessageBox.Show("One Record has been Update.", "Record Update.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                OracleCommand cmd = new OracleCommand("deletebranch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbrid", Int32.Parse(txtbranchid.Text));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbranch();
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
            OracleCommand cmd = new OracleCommand("searchbranch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vbrname", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();



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
            frmbranchreport sr = new frmbranchreport();
            sr.ShowDialog();
        }
    }
}
