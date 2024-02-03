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
    public partial class frmtranprice : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmtranprice()
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
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addprice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vsize", txtsize.Text);
                cmd.Parameters.Add("vminprice", txtminprice.Text);
                cmd.Parameters.Add("vmaxprice", txtmaxprice.Text);
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranprice();
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
        private void showtranprice()
        {
            OracleCommand cmd = new OracleCommand("showtranprice", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tranprice");
            dataGridView1.DataSource = ds.Tables["tranprice"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txtsize.Clear();
            txtprice.Clear();
            txtminprice.Clear();
            txtmaxprice.Clear();
            txtgoodid.Clear();
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

        private void frmtranprice_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showtranprice();
            showsource();
            showdest();
            clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updateprice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranpriceid", txtgoodid.Text);
                cmd.Parameters.Add("vsize", txtsize.Text);
                cmd.Parameters.Add("vminprice", txtminprice.Text);
                cmd.Parameters.Add("vmaxprice", txtmaxprice.Text);
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranprice();
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtgoodid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtsize.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtminprice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmaxprice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbosource.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbodest.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("deleteprice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranpriceid", txtgoodid.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtranprice();
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
            OracleCommand cmd = new OracleCommand("searchprice", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vsize", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
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
            frmpricereport sr = new frmpricereport();
            sr.ShowDialog();
        }
    }
}
