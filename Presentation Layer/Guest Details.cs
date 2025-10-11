using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

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

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastname = txtLastname.Text;
            string ID = txtID.Text;
            string address = txtAddress.Text;
            string PhoneNo = txtPhoneNo.Text;
            string email = txtEmail.Text;

            //ensure all fields are not empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(PhoneNo)
                || string.IsNullOrEmpty(email))

            {
                MessageBox.Show("Enter information in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //lastname and name is only letters

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$" ) || !Regex.IsMatch(lastname, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Fields can only contain letters and spaces", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //ID is only 13 digits
            if (!long.TryParse(ID, out _) || ID.Length != 13)
            {
                MessageBox.Show("ID must be 13 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Phone number is only 10 digits
            if (!long.TryParse(PhoneNo, out _) || PhoneNo.Length != 10)
            {
                MessageBox.Show("Phone number must be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //email must contain @
            if (!email.Contains("@"))
            {
                MessageBox.Show("Invalid email, email should contain '@'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Guest newGuest = new Guest();

            //save to database
            try
            {
                guestController.AddGuest(newGuest);
                MessageBox.Show("Guest added to records successfully!", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayGuestDetails(newGuest);
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding Guest to records" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int guestID = Convert.ToInt32(txtSearch.Text);

            //ensure guestid textbox is not empty
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Enter information in field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSearch.Text.Trim(), out guestID))
            {
                MessageBox.Show("GuestID must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
                
                GuestDB guestDB = new GuestDB();

            //search for GuestID
                if (guestDB.GuestRecordExists(guestID))
                {
                    MessageBox.Show("Guest already exists in records", "Guest Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageReservation manageReservation = new ManageReservation();
                    manageReservation.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Guest does not exist in records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnlNewGuest.Visible = true;

                }
            
            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {    
            About_Page aboutPage = new About_Page();
            aboutPage.Show();
            this.Hide();
 
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmCreateGuest creatGuest = new frmCreateGuest();
            creatGuest.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void frmCreateGuest_Load(object sender, EventArgs e)
        {

        }
    }
    }


