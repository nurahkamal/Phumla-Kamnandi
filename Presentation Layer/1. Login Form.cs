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
    public partial class Login_Form : Form
    {
        #region login attempts
        private int loginAttempts = 0;
        private const int MaxLoginAttempts = 3;
        #endregion

        public Login_Form()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        #region  Exit and LoginButtons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           ///Validation 1 : when the username is empty
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.");
                txtUsername.Focus();
                return;
            }
            ///validation 2 : when the password is empty
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.");
                txtPassword.Focus();
                return;
            }

           ///validation 3 : when there is spaces in the username
            if (username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces.");
                txtUsername.Focus();
                return;
            }

            //validation 4 : when ther password is less than 4 characters
            
            if (password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.");
                txtPassword.Focus();
                return;
            }

            //validation 5:when teh user  has exceeded the login attempts
            loginAttempts++;
            if (loginAttempts > MaxLoginAttempts)
            {
                MessageBox.Show("Too many failed login attempts. Try again later.");
                btnLogin.Enabled = false;
                return;
            }

            /// password is succesful takes you to the about page
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin")
            {
                this.Hide();
                About_Page aboutPage = new About_Page();
                aboutPage.Show();
            }
            else
            {
                MessageBox.Show($"Invalid username or password. Attempt {loginAttempts} of {MaxLoginAttempts}.");
            }
        }




        #endregion
        #region Forgot Password Button
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Please contact the system administrator or IT support to reset your password.",
        "Forgot Password",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    );
        }
        #endregion
    }
}
