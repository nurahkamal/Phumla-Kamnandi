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

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.");
                txtPassword.Focus();
                return;
            }

            if (username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces.");
                txtUsername.Focus();
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.");
                txtPassword.Focus();
                return;
            }

            loginAttempts++;
            if (loginAttempts > MaxLoginAttempts)
            {
                MessageBox.Show("Too many failed login attempts. Try again later.");
                btnLogin.Enabled = false;
                return;
            }

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
                            UpdateLoginTime(username);

                            MessageBox.Show($"Welcome {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            Home_Pagecs homePage = new Home_Pagecs();
                            homePage.Show();
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

        private void UpdateLoginTime(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET LastLoginTime = @loginTime WHERE Username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@loginTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error updating login time: " + ex.Message);
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

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}