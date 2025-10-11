using Microsoft.Reporting.WinForms;
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
    public partial class About_Page : Form
    {
        public About_Page()
        {
            InitializeComponent();
        }
        int Count = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            frmCreateGuest creatGuest = new frmCreateGuest();
            creatGuest.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ManageReservation manageReservation = new ManageReservation();
            manageReservation.Show();
            this.Hide();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ManageGuest updatebooking = new ManageGuest();
            updatebooking.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home_Pagecs home = new Home_Pagecs();
            home.Show();
            this.Hide();
        }

        private void btnGuestEnquiries_Click(object sender, EventArgs e)
        {
            ManageGuest guestenquiries = new ManageGuest();
            guestenquiries.Show();
            this.Hide();
        }
    }
}
