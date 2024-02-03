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
using System.IO;
namespace Bus_bookig.Forms
{
    public partial class frmbus : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmbus()
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
            label5.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label9.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;


        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtplate.Text))
            {
                MessageBox.Show("Please Enter Plate number !", "Required plate number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtplate.Focus();
                return;
            }
            try
            {
                conn.Open();
                // create memory stream object
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                OracleCommand cmd = new OracleCommand("addbus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusplateno",txtplate.Text);
                cmd.Parameters.Add("vbusseat1", txt1st.Text);
                cmd.Parameters.Add("vbusseat2", txt2nd.Text);
                cmd.Parameters.Add("vtoilet", txttoilet.Text);
                cmd.Parameters.Add("vmade", dateTimePickermade.Value);
                cmd.Parameters.Add("vmachine", txtmachine.Text);
                cmd.Parameters.Add("vcountry", txtcountry.Text);
                cmd.Parameters.Add("vbought", dateTimePickerbought.Value);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vcolor", txtcolor.Text);
                cmd.Parameters.Add("vphoto", OracleDbType.Blob).Value = ms.ToArray();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbus();
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

        private void frmbus_Load(object sender, EventArgs e)
        {
            showbus();
            clear();
            dataGridView1.ClearSelection();
            LoadTheme();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "images | *.png; *.jpg; *.jpeg; *.bmp;";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void showbus()
        {
            OracleCommand cmd = new OracleCommand("showbus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "bus");
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.DataSource = ds.Tables["bus"];
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridView1.Columns[11];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            adapter.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        private void clear()
        {
            txt1st.Clear();
            txt2nd.Clear();
            txtsearch.Clear();
            txtbus.Clear();
            txtcolor.Clear();
            txtcountry.Clear();
            txtmachine.Clear();
            txtplate.Clear();
            txtprice.Clear();
            txttoilet.Clear();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtbus.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtplate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt1st.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt2nd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttoilet.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePickermade.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtmachine.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcountry.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePickerbought.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtcolor.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            byte[] data = (byte[])dataGridView1.CurrentRow.Cells[11].Value;
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                // create memory stream object
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                OracleCommand cmd = new OracleCommand("updatebus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusid", txtbus.Text);
                cmd.Parameters.Add("vbusplateno", txtplate.Text);
                cmd.Parameters.Add("vbusseat1", txt1st.Text);
                cmd.Parameters.Add("vbusseat2", txt2nd.Text);
                cmd.Parameters.Add("vtoilet", txttoilet.Text);
                cmd.Parameters.Add("vmade", dateTimePickermade.Value);
                cmd.Parameters.Add("vmachine", txtmachine.Text);
                cmd.Parameters.Add("vcountry", txtcountry.Text);
                cmd.Parameters.Add("vbought", dateTimePickerbought.Value);
                cmd.Parameters.Add("vprice", txtprice.Text);
                cmd.Parameters.Add("vcolor", txtcolor.Text);
                cmd.Parameters.Add("vphoto", OracleDbType.Blob).Value = ms.ToArray();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbus();
                clear();
                MessageBox.Show("One Record has been update.", "Record Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                OracleCommand cmd = new OracleCommand("deletebus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vbusid",txtbus.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showbus();
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
            OracleCommand cmd = new OracleCommand("searchbus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vbusplateno", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
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
            frmbusreport sr = new frmbusreport();
            sr.ShowDialog();
        }
    }
}
