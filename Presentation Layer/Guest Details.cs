using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class frmCreateGuest : Form
    {
        public frmCreateGuest()
        {
            InitializeComponent();
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

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(lastname, @"^[a-zA-Z\s]+$"))
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


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int guestID = Convert.ToInt32(txtSearch.Text);
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
    }
}

