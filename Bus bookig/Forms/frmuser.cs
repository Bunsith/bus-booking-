using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig.Forms
{
    public partial class frmuser : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmuser()
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
            label3.ForeColor = ThemeColor.PrimaryColor;
        }

        private void frmuser_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showuser();
            dataGridView1.ClearSelection();
            clear();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtusername.Text))
            {
                MessageBox.Show("Please Enter User Name !", "Required User Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtusername.Focus();
                return;
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("adduser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vusername", txtusername.Text);
                cmd.Parameters.Add("vpassword", txtpassword.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showuser();
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
        private void showuser()
        {
            OracleCommand cmd = new OracleCommand("showuser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "user");
            dataGridView1.DataSource = ds.Tables["user"];
            ds.Dispose();
            adapter.Dispose();
            cmd.Dispose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtuserid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtusername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtpassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updateuser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vuserid", Int32.Parse(txtuserid.Text));
                cmd.Parameters.Add("vusername", txtusername.Text);
                cmd.Parameters.Add("vpassword", txtpassword.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showuser();
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
                OracleCommand cmd = new OracleCommand("deleteuser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vuserid", Int32.Parse(txtuserid.Text));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showuser();
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
        private void clear()
        {
            txtuserid.Clear();
            txtusername.Clear();
            txtpassword.Clear();
        }
    }
}
