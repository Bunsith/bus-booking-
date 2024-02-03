using Bus_bookig.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_bookig
{
    public partial class frmMain : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public frmMain()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (btnSender != null)
                {
                    if (currentButton != (Button)btnSender)
                    {
                        DisableButton();
                        Color color = SelectThemeColor();
                        currentButton = (Button)btnSender;
                        currentButton.BackColor = color;
                        currentButton.ForeColor = Color.White;
                        currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                       btnCloseChildForm.Visible = true;
                    }
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btndashbord_Click(object sender, EventArgs e)
        {
            
        }

        private void btnorderticket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmtranticket(), sender);
        }

        private void btntransport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmtransport(), sender);
        }

        private void btntranschedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmtranschedule(), sender);
        }

        private void btntranprice_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmtranprice(), sender);
        }

        private void btnbranchinfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmbranch(), sender);
        }

        private void btnbusinfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmbus(), sender);
        }

        private void busexp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmbusexpen(), sender);
        }

        private void btnempinfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmemployee(), sender);
        }

        private void btndriver_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmdriver(), sender);
        }

        private void btnposition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmposition(), sender);
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmuser(), sender);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            OpenChildForm(new Forms.frmtransport(), sender);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tranTicketReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbotranticketreport sr = new cbotranticketreport();
            sr.ShowDialog();
        }

        private void transportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbotransportreport sr = new cbotransportreport();
            sr.ShowDialog();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.frmdashboard(), sender);
        }
    }
}
