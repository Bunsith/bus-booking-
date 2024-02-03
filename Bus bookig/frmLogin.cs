using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus_bookig.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig
{
    public partial class frmLogin : Form
    {
        OracleConnection conn = DBconnection.connect();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtpass.UseSystemPasswordChar == true)
            {
                txtpass.UseSystemPasswordChar = false;

            }
            else
            {
                txtpass.UseSystemPasswordChar = true;

            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuser.Text))
            {
                MessageBox.Show("UserName is required!", "Missing UserName", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtuser.Focus();
            }
            else if (string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Password is require", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpass.Focus();
            }
            else
            {
                try
                {
                    conn.Open();
                    string oracle_select = "SELECT * FROM tbluser WHERE username='" + txtuser.Text.Trim() + "' AND password='" + txtpass.Text.Trim() + "'";
                    //Create data
                    OracleDataAdapter adapter = new OracleDataAdapter(oracle_select,conn);
                    DataTable dt = new DataTable();

                    //Fill data in dt
                    adapter.Fill(dt);
                     
                    if (dt.Rows.Count ==1)
                    {
                        //show main form
                        frmMain frm = new frmMain();
                        this.Hide(); // Hide Login Form
                        frm.Show(); // Show main form


                    }
                    else
                    {
                        MessageBox.Show("Failed to login the user.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Login Faile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            frmregister sr = new frmregister();
            sr.ShowDialog();
        }
    }
}
