using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class frmCreateGuest : Form
    {
        private GuestController guestController;

        public frmCreateGuest()
        {
            InitializeComponent();
            guestController = new GuestController();
        }

        #region Helper Methods
        private void DisplayGuestDetails(Guest guest)
        {
            txtName.Text = guest.Pname;
            txtLastname.Text = guest.Psurname;
            txtID.Text = guest.Pid;
            txtEmail.Text = guest.Pemail;
            txtPhoneNo.Text = guest.Pphone;
            txtAddress.Text = guest.Paddress;
        }

        private void Clear()
        {
            txtName.Clear();
            txtLastname.Clear();
            txtID.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();
            txtAddress.Clear();
        }
        #endregion

        #region Button Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Validate input
            string name = txtName.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string idText = txtSearch.Text.Trim();
            int guestID;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(lastname) ||
                string.IsNullOrWhiteSpace(idText))
            {
                MessageBox.Show("Enter information in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Name and lastname validation
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(lastname, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Names can only contain letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ID must be numeric
            if (!int.TryParse(idText, out guestID))
            {
                MessageBox.Show("GuestID must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create new guest from input
            Guest newGuest = new Guest
            {
                Pname = txtName.Text.Trim(),
                Psurname = txtLastname.Text.Trim(),
                Pid = txtID.Text.Trim(),
                Pemail = txtEmail.Text.Trim(),
                Pphone = txtPhoneNo.Text.Trim(),
                Paddress = txtAddress.Text.Trim()
            };

            // Validation
            if (string.IsNullOrWhiteSpace(newGuest.Pname) ||
                string.IsNullOrWhiteSpace(newGuest.Psurname) ||
                string.IsNullOrWhiteSpace(newGuest.Pid))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                MessageBox.Show("Guest added to records successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayGuestDetails(newGuest);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding Guest to records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this);
            report.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About_Page aboutPage = new About_Page();
            aboutPage.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmCreateGuest createGuest = new frmCreateGuest();
            createGuest.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            User userinfo = new User();
            userinfo.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
