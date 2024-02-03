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
    public partial class frmemployee : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmemployee()
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
            label10.ForeColor = ThemeColor.PrimaryColor;
           

        }

        private void frmemployee_Load(object sender, EventArgs e)
        {
            showemployee();
            clear();
            dataGridView1.ClearSelection();
            LoadTheme();
            showposition();
            showbranch();
      
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtname.Text))
            {
                MessageBox.Show("Please Enter Name !", "Required Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            try
            {
                conn.Open();
                // create memory stream object
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                OracleCommand cmd = new OracleCommand("addemployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
               cmd.Parameters.Add("vbranch",cbobranch.SelectedValue);
                cmd.Parameters.Add("vempname", txtname.Text);
                cmd.Parameters.Add("vgender", txtgender.Text);
                cmd.Parameters.Add("vempcardid", txtcardid.Text);
                cmd.Parameters.Add("vempphoneno", txtphone.Text);
                cmd.Parameters.Add("vempaddress", txtaddress.Text);
                cmd.Parameters.Add("vpos",cbopositionid.SelectedValue);
               cmd.Parameters.Add("vhire", dateTimePicker1.Value);
                
               cmd.Parameters.Add("vimg", OracleDbType.Blob).Value = ms.ToArray();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showemployee();
                clear();
                showposition();
                showbranch();
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

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "images | *.png; *.jpg; *.jpeg; *.bmp;";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void showemployee()
        {
            OracleCommand cmd = new OracleCommand("showemployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "employee");
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.DataSource = ds.Tables["employee"];
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridView1.Columns[9];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
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
            txtemployeeid.Clear();
            txtname.Clear();
            txtgender.Clear();
            cbobranch.Text = string.Empty;
            cbopositionid.Text = string.Empty;
            
        }
        private void showposition()
        {
            string sql_select = "SELECT posid, position FROM tblposition";
            // create data adater object
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            // create dataset object
            DataSet ds = new DataSet();

            // fill data into dataset object: ds
            adapter.Fill(ds, "position");

            cbopositionid.DataSource = ds.Tables["position"];
            cbopositionid.DisplayMember = "position";
            cbopositionid.ValueMember = "posid";

            ds.Dispose();
            adapter.Dispose();
        }
        private void showbranch()
        {
            string sql_select = "SELECT brid, brname FROM tblbranch";
            // create data adater object
            OracleDataAdapter adapter = new OracleDataAdapter(sql_select, conn);
            // create dataset object
            DataSet ds = new DataSet();

            // fill data into dataset object: ds
            adapter.Fill(ds, "branch");

            cbobranch.DataSource = ds.Tables["branch"];
            cbobranch.DisplayMember = "brname";
            cbobranch.ValueMember = "brid";

            ds.Dispose();
            adapter.Dispose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
            txtemployeeid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbobranch.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtgender.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtcardid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtphone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbopositionid.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            byte[] data = (byte[])dataGridView1.CurrentRow.Cells[9].Value;
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
                OracleCommand cmd = new OracleCommand("updateemployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vempid", txtemployeeid.Text);
                cmd.Parameters.Add("vbranch", cbobranch.SelectedValue);
                cmd.Parameters.Add("vempname", txtname.Text);
                cmd.Parameters.Add("vgender", txtgender.Text);
                cmd.Parameters.Add("vempcardid", txtcardid.Text);
                cmd.Parameters.Add("vempphoneno", txtphone.Text);
                cmd.Parameters.Add("vempaddress", txtaddress.Text);
                cmd.Parameters.Add("vpos", cbopositionid.SelectedValue);
                cmd.Parameters.Add("vhire", dateTimePicker1.Value);

                cmd.Parameters.Add("vimg", OracleDbType.Blob).Value = ms.ToArray();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showemployee();
                clear();
                showposition();
                showbranch();
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
                OracleCommand cmd = new OracleCommand("deleteemployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vempid", Int32.Parse(txtemployeeid.Text));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                showemployee();
                clear();
                showposition();
                showbranch();
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
            OracleCommand cmd = new OracleCommand("searchemployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("vempname", OracleDbType.Varchar2).Value = txtsearch.Text.Trim();
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
            frmemployeereport sr = new frmemployeereport();
            sr.ShowDialog();
        }
    }
}
