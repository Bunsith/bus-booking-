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
    public partial class frmbusexpen : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmbusexpen()
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


        }
        private void btnadd_Click(object sender, EventArgs e)
        {
          
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("addbusexp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusid", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriverid", cbodriver.SelectedValue);
                cmd.Parameters.Add("vexpence", txtexp.Text);
                cmd.Parameters.Add("vdesc", txtdesc.Text);
                cmd.Parameters.Add("vexpdate", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbusexp();
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

        private void frmbusexpen_Load(object sender, EventArgs e)
        {
            showbusexp();
            clear();
            dataGridView1.ClearSelection();
            LoadTheme();
            showbus();
            showdriver();
        }
        private void showbusexp()
        {
            OracleCommand cmd = new OracleCommand("showbusexp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "busexp");
            dataGridView1.DataSource = ds.Tables["busexp"];
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txtbusexpid.Clear();
            txtdesc.Clear();
            txtexp.Clear();

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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("updatebusexp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusexpid", txtbusexpid.Text);
                cmd.Parameters.Add("vbusid", cbobus.SelectedValue);
                cmd.Parameters.Add("vdriverid", cbodriver.SelectedValue);
                cmd.Parameters.Add("vexpence", txtexp.Text);
                cmd.Parameters.Add("vdesc", txtdesc.Text);
                cmd.Parameters.Add("vexpdate", dateTimePicker1.Value);              
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbusexp();
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
                OracleCommand cmd = new OracleCommand("deletebusexp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusexpid", txtbusexpid.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbusexp();
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
            txtbusexpid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbobus.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbodriver.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtexp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdesc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            frmbusexpenreport sr = new frmbusexpenreport();
            sr.ShowDialog();
        }
    }
}
