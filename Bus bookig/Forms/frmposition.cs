using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig.Forms
{
    public partial class frmposition : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmposition()
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
            label3.ForeColor = ThemeColor.PrimaryColor;
        }

        private void frmposition_Load(object sender, EventArgs e)
        {
            showposition();
            clear();
            dataGridView1.ClearSelection();
            LoadTheme();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtposition.Text))
            {
                MessageBox.Show("Please Enter Position !", "Required Position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtposition.Focus();
                return;
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addposition", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vposition", txtposition.Text);
                cmd.Parameters.Add("vsalary", txtsalary.Text);
                cmd.Parameters.Add("vnote", txtnote.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showposition();
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
        private void showposition()
        {
            OracleCommand cmd = new OracleCommand("showposition", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "position");
            dataGridView1.DataSource = ds.Tables["position"];
            ds.Dispose();
            adapter.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txtposid.Clear();
            txtposition.Clear();
            txtsalary.Clear();
            txtsearch.Clear();
            txtnote.Clear();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtposid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtposition.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsalary.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtnote.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updateposition", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vposid", Int32.Parse(txtposid.Text));
                cmd.Parameters.Add("vposition", txtposition.Text);
                cmd.Parameters.Add("vsalary", txtsalary.Text);
                cmd.Parameters.Add("vnote", txtnote.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showposition();
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
                OracleCommand cmd = new OracleCommand("deleteposition", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vposid", Int32.Parse(txtposid.Text));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showposition();
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
            OracleCommand cmd = new OracleCommand("searchposition", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vposition", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();



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
    }
}
