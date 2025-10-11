using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class Home_Pagecs : Form
    {
        public Home_Pagecs()
        {
            InitializeComponent();

        }
        int Count = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Count < 11)
            {
                pictureBox1.Image = imageList1.Images[Count];
                Count++;
            }
            else
                Count = 0;
        }

        private void btnGuestDetails_Click(object sender, EventArgs e)
        {
            frmCreateGuest creatGuest = new frmCreateGuest();
            creatGuest.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            ManageReservation manageReservation = new ManageReservation();
            manageReservation.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About_Page about = new About_Page();
            about.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManageGuest updatebooking = new ManageGuest();
            updatebooking.Show();
            this.Hide();
        }

        private void btnGuestEnquiries_Click(object sender, EventArgs e)
        {
            ManageGuest guestenquiries = new ManageGuest();
            guestenquiries.Show();
            this.Hide();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this); // pass "this" form
            report.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {

            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void Home_Pagecs_Load(object sender, EventArgs e)
        {
            // Set Home button as selected
            btnHome.FillColor = Color.FromArgb(75, 65, 57);
            btnHome.ForeColor = Color.White;
            btnHome.BorderColor = Color.FromArgb(177, 153, 127);
            btnHome.BorderThickness = 1;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            User userForm = new User();
            userForm.Show();
            this.Hide();
        }
    }
}
