using Phumla_Kamnandi.Business_Layer;
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
    public partial class ManageEdits : Form
    {
        public ManageEdits()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            ManageReservation rForm = new ManageReservation();
            rForm.Show();
            this.Hide();
        }

        private void ManageEdits_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            ManageGuest gForm = new ManageGuest();
            gForm.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            About_Page about = new About_Page();
            about.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MonthlySalesReport report = new MonthlySalesReport();
            report.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this); // pass "this" form
            report.Show();
            this.Hide();
        }
    }
}
