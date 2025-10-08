using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class Login_Form : Form
    {
        #region login attempts
        private int loginAttempts = 0;
        private const int MaxLoginAttempts = 3;
        #endregion

        // CONN STRING
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";


        public Login_Form()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        #region Exit and Login Buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            //  Empty username
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.");
                txtUsername.Focus();
                return;
            }

            //  no password
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.");
                txtPassword.Focus();
                return;
            }

            // spaces
            if (username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces.");
                txtUsername.Focus();
                return;
            }

            // length
            if (password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.");
                txtPassword.Focus();
                return;
            }

            // attemmpts
            loginAttempts++;
            if (loginAttempts > MaxLoginAttempts)
            {
                MessageBox.Show("Too many failed login attempts. Try again later.");
                btnLogin.Enabled = false;
                return;
            }

            // DB
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE Username = @username AND PasswordHash = @password AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                           
                            MessageBox.Show($"Welcome {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            About_Page aboutPage = new About_Page();
                            aboutPage.Show();
                        }
                        else
                        {
                            MessageBox.Show($"Invalid username or password. Attempt {loginAttempts} of {MaxLoginAttempts}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        #endregion

        #region Forgot Password
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please contact the system administrator or IT support to reset your password.",
                "Forgot Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion

        private void Login_Form_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
