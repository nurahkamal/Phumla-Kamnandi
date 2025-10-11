using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Media;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class ReportLoginFormcs : Form
    {
        #region VARS n Consts
        // keep trak of login attemps
        private int loginAttempts = 0;
        private const int MaxLoginAttempts = 3;

        // db conn string
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        // warnign stuff
        private System.Timers.Timer warningTimer;
        private bool isWarningVisible = false;
        private Label warningLabel;
        private SoundPlayer warningSound;
        #endregion

        #region constructor
        public ReportLoginFormcs()
        {
            InitializeComponent();

            // hide pass chars
            txtPassword.UseSystemPasswordChar = true;

            // setup warnign system
            InitializeWarningSystem();

            // wire up all the buttons etc
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;
            btnForgotPassword.Click += btnForgotPassword_Click;
            this.Load += ReportLoginFormcs_Load;
        }
        #endregion

        #region warnign system
        private void InitializeWarningSystem()
        {
            // label that flashes when ppl try login( vanessa and nurah)
            warningLabel = new Label();
            warningLabel.Text = "⚠️ WARNING: Unauthorized access attempt detected! ⚠️";
            warningLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            warningLabel.ForeColor = Color.Red;
            warningLabel.BackColor = Color.Yellow;
            warningLabel.TextAlign = ContentAlignment.MiddleCenter;
            warningLabel.Dock = DockStyle.Top;
            warningLabel.Height = 40;
            warningLabel.Visible = false;
            this.Controls.Add(warningLabel);
            warningLabel.BringToFront();

            // flash timer
            warningTimer = new System.Timers.Timer(500);
            warningTimer.Elapsed += WarningTimer_Elapsed;
            warningTimer.AutoReset = true;

            // sound for warning
            warningSound = new SoundPlayer();
        }

        private void WarningTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // flash the warning label 
            if (warningLabel.InvokeRequired)
            {
                warningLabel.Invoke(new Action(() =>
                {
                    isWarningVisible = !isWarningVisible;
                    warningLabel.Visible = isWarningVisible;
                }));
            }
            else
            {
                isWarningVisible = !isWarningVisible;
                warningLabel.Visible = isWarningVisible;
            }
        }

        private void ShowUnauthorizedWarning()
        {
            // start flashing if not started
            if (!warningTimer.Enabled)
            {
                warningTimer.Start();
            }

            // sound
            PlayWarningSound();

            //debug
            LogSecurityAttempt($"Unauthorized access attempt by user: {txtUsername.Text.Trim()} at {DateTime.Now}");
        }

        private void StopWarning()
        {
            // stop flash
            if (warningTimer.Enabled)
            {
                warningTimer.Stop();
                warningLabel.Visible = false;
                isWarningVisible = false;
            }
        }

        private void PlayWarningSound()
        {
            try
            {
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"sound error: {ex.Message}");
            }
        }

        private void LogSecurityAttempt(string message)
        {
            // just for debug, later can log 2 db or file
            System.Diagnostics.Debug.WriteLine($"SECURITY WARNING: {message}");
        }
        #endregion

        #region form events
        private void ReportLoginFormcs_Load(object sender, EventArgs e)
        {
            txtUsername.Focus(); // focus username on load 
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // clean up warning stuff when closing
            StopWarning();
            warningTimer?.Dispose();
            warningSound?.Dispose();
            base.OnFormClosing(e);
        }
        #endregion

        #region button events
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close this form
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // get user inputz
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // empty username?
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter ur username.");
                txtUsername.Focus();
                return;
            }

            // empty pass?
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter ur password.");
                txtPassword.Focus();
                return;
            }

            // spaces check
            if (username.Contains(" "))
            {
                MessageBox.Show("username cant have spaces lol.");
                txtUsername.Focus();
                return;
            }

            // password length check
            if (password.Length < 4)
            {
                MessageBox.Show("Password must b at least 4 chars");
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // get role from db
                    string query = "SELECT Role FROM Users WHERE Username = @username AND PasswordHash = @password AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object roleObj = cmd.ExecuteScalar();

                        if (roleObj != null)
                        {
                            string role = roleObj.ToString();

                            if (role == "Manager")
                            {
                                StopWarning();
                                MessageBox.Show($"Welcome Manager {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // hide this form and open report select form
                                this.Hide();
                                ReportSelectionForm reportSelection = new ReportSelectionForm();
                                reportSelection.Show();
                            }
                            else
                            {
                                // user not manager, increase attempts
                                loginAttempts++;
                                ShowUnauthorizedWarning();
                                MessageBox.Show($"Access denied. Only managers can access reports. Attempt {loginAttempts} of {MaxLoginAttempts}.",
                                    "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                // check max attempts
                                if (loginAttempts >= MaxLoginAttempts)
                                {
                                    MessageBox.Show("Too many failed login attempts. System will now exit.",
                                        "Security Breach", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.Exit(); // exit completely
                                }
                            }
                        }
                        else
                        {
                            // wrong username/password
                            loginAttempts++;

                            if (loginAttempts >= 2)
                            {
                                ShowUnauthorizedWarning(); // start warning if repeated fail
                            }

                            if (loginAttempts >= MaxLoginAttempts)
                            {
                                MessageBox.Show("Too many failed login attempts. System will now exit.",
                                    "Security Breach", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit(); // full exit
                            }
                            else
                            {
                                MessageBox.Show($"Invalid username or password. Attempt {loginAttempts} of {MaxLoginAttempts}.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to db: " + ex.Message);
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // forgot password
            MessageBox.Show(
                "Please contact the system administrator or IT support to reset your password.",
                "Forgot Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion
    }
}
