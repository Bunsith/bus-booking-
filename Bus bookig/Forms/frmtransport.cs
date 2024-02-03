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
    public partial class frmtransport : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmtransport()
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
            //label3.ForeColor = ThemeColor.PrimaryColor;
            //label7.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;
            
        }
        

        private void clear()
        {
            txttranid.Clear();
            txtrephone.Clear();
            txtsephone.Clear();
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

        private void frmtransport_Load(object sender, EventArgs e)
        {
            LoadTheme();
            showtran();




            showsource();
            showdest();
            showsize();
            showemp();
            remove();
        }

        

      

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addtran", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vrecevie", txtrephone.Text);
                cmd.Parameters.Add("vsent", txtsephone.Text);
                cmd.Parameters.Add("vdate", dateTimePicker2.Value);
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vsizes", cbosize.SelectedValue);
                cmd.Parameters.Add("vdesc", txtdesc.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtran();
                showemp();
                showsource();
                showdest();
                showsize();

                remove();
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
        private void showtran()
        {
            OracleCommand cmd = new OracleCommand("showtran", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tran");
            dataGridView2.DataSource = ds.Tables["tran"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void remove()
        {
            txtprice.Clear();
            txtdesc.Clear();
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
        private void showsize()
        {
            string sql_select = "SELECT goodsize FROM tblgoodtranprice";
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "size");

            cbosize.DataSource = ds.Tables["size"];
            cbosize.DisplayMember = "goodsize";
            cbosize.ValueMember = "goodsize";

            ds.Dispose();
            adapter.Dispose();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatetran", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranid", txttranid.Text);
                cmd.Parameters.Add("vempid", cboemployee.SelectedValue);
                cmd.Parameters.Add("vrecevie", txtrephone.Text);
                cmd.Parameters.Add("vsent", txtsephone.Text);
                cmd.Parameters.Add("vdate", dateTimePicker2.Value);
                cmd.Parameters.Add("vsource", cbosource.SelectedValue);
                cmd.Parameters.Add("vdest", cbodest.SelectedValue);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vsizes", cbosize.SelectedValue);
                cmd.Parameters.Add("vdesc", txtdesc.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtran();
                showemp();
                showsource();
                showdest();
                showsize();

                remove();
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

        private void btnremove_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("deletetran", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vtranid", txttranid.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showtran();
                showemp();
                showsource();
                showdest();
                showsize();

                remove();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            txttranid.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cboemployee.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtrephone.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtsephone.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            cbosource.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            cbodest.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            txtprice.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            cbosize.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            txtdesc.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();

        }

        private void btninvoice_Click(object sender, EventArgs e)
        {
            int orderid = Convert.ToInt32(txttranid.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString());
            frmtransportticket sr = new frmtransportticket(orderid);
            sr.ShowDialog();
        }
    }
}
