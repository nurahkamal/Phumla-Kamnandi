using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class User : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadActiveUsers();
            LoadUserStatistics();
        }

        private void LoadActiveUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT Username, Role, FullName, 
                                    ISNULL(CONVERT(varchar, LastLoginTime, 120), 'Never logged in') AS LoginTime
                                    FROM Users 
                                    WHERE IsActive = 1";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void UpdateUserLoginTime(string username)
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this);
            report.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadActiveUsers();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadUserStatistics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Total users
                    string totalQuery = "SELECT COUNT(*) FROM Users";
                    SqlCommand totalCmd = new SqlCommand(totalQuery, conn);
                    lblTotalCount.Text = totalCmd.ExecuteScalar().ToString();

                    // Active users
                    string activeQuery = "SELECT COUNT(*) FROM Users WHERE IsActive = 1";
                    SqlCommand activeCmd = new SqlCommand(activeQuery, conn);
                    lblActiveCount.Text = activeCmd.ExecuteScalar().ToString();

                    // Users logged in today
                    string todayQuery = "SELECT COUNT(*) FROM Users WHERE CAST(LastLoginTime AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand todayCmd = new SqlCommand(todayQuery, conn);
                    lblTodayCount.Text = todayCmd.ExecuteScalar().ToString();

                    // Most common role
                    string roleQuery = @"SELECT TOP 1 Role FROM Users 
                               WHERE IsActive = 1 
                               GROUP BY Role 
                               ORDER BY COUNT(*) DESC";
                    SqlCommand roleCmd = new SqlCommand(roleQuery, conn);
                    var result = roleCmd.ExecuteScalar();
                    lblRoleValue.Text = result?.ToString() ?? "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }
    }
}