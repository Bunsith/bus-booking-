using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_bookig.Forms
{
    public partial class frmregister : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmregister()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuser.Text))
            {
                MessageBox.Show("Please Enter User Name !", "Required User Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Focus();
                return;
            }
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("adduser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // Add value
                cmd.Parameters.Add("vusername", txtuser.Text);
                cmd.Parameters.Add("vpassword", txtpass.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                    //show main form
                    frmLogin frm = new frmLogin();
                    this.Hide(); // Hide Login Form
                //this .Show();

                MessageBox.Show("Register successfully.", "Record Registered.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label4_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtuser.Clear();
        }
    }
}
