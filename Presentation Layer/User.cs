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
        private DataTable originalDataTable;

        public User()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadActiveUsers();
            LoadUserStatistics();
            cmbFilter.SelectedIndex = 0;
        }


        private void LoadActiveUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT 
                    UserID,
                    Username, 
                    Role, 
                    FullName, 
                    ISNULL(CONVERT(varchar, LastLoginTime, 120), 'Never logged in') AS LoginTime,
                    CASE 
                        WHEN IsActive = 1 THEN 'Active'
                        ELSE 'Inactive'
                    END AS Status
                    FROM Users 
                    ORDER BY IsActive DESC, LastLoginTime DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    originalDataTable = new DataTable();
                    da.Fill(originalDataTable);

                    // Let DataGridView auto-generate columns
                    guna2DataGridView1.AutoGenerateColumns = true;
                    guna2DataGridView1.DataSource = originalDataTable;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void ApplyFiltersAndSearch()
        {
            if (originalDataTable == null) return;

            try
            {
                DataView dv = originalDataTable.DefaultView;
                string searchText = txtSearch.Text.Trim();
                string filterCondition = "";

                // Apply search filter
                if (!string.IsNullOrEmpty(searchText))
                {
                    filterCondition += $"(Username LIKE '%{searchText}%' OR FullName LIKE '%{searchText}%' OR Role LIKE '%{searchText}%')";
                }

                
                string selectedFilter = cmbFilter.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedFilter) && selectedFilter != "All Users")
                {
                    if (!string.IsNullOrEmpty(filterCondition))
                        filterCondition += " AND ";

                    switch (selectedFilter)
                    {
                        case "Active Only":
                            filterCondition += "Status = 'Active'";
                            break;
                        case "Inactive Only":
                            filterCondition += "Status = 'Inactive'";
                            break;
                        case "Managers":
                            filterCondition += "Role = 'Manager'";
                            break;
                        case "Receptionists":
                            filterCondition += "Role = 'Receptionist'";
                            break;
                        case "Cleaners":
                            filterCondition += "Role = 'Cleaner'";
                            break;
                        case "Admins":
                            filterCondition += "Role = 'Admin'";
                            break;
                    }
                }

                dv.RowFilter = filterCondition;
                guna2DataGridView1.DataSource = dv.ToTable();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filters: " + ex.Message);
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

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedUserInfo();
        }

        private void WireUpEvents()
        {
            // Control panel events
            btnRefresh.Click += btnRefresh_Click;
            btnAddUser.Click += btnAddUser_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            // Action buttons
            btnEditUser.Click += btnEditUser_Click;
            btnDeactivate.Click += btnDeactivate_Click;
            btnResetPassword.Click += btnResetPassword_Click;

            // Data grid
            guna2DataGridView1.SelectionChanged += guna2DataGridView1_SelectionChanged;
        }

        // FIXED: Correct column names for selected user info
        private void UpdateSelectedUserInfo()
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // Use correct column names - these should match your DataGridView column names
                lblUsernameValue.Text = GetCellValue(selectedRow, "Username");
                lblRoleValue.Text = GetCellValue(selectedRow, "Role");
                lblStatusValue.Text = GetCellValue(selectedRow, "Status");
                lblLastLoginValue.Text = GetCellValue(selectedRow, "LoginTime");

                // Update deactivate button text based on status
                string status = GetCellValue(selectedRow, "Status");
                btnDeactivate.Text = status == "Active" ? "Deactivate" : "Activate";
                btnDeactivate.FillColor = status == "Active" ?
                    Color.FromArgb(255, 193, 7) : // Orange for deactivate
                    Color.FromArgb(40, 167, 69);  // Green for activate
            }
            else
            {
                // Clear details if no selection
                lblUsernameValue.Text = "-";
                lblRoleValue.Text = "-";
                lblStatusValue.Text = "-";
                lblLastLoginValue.Text = "-";
                btnDeactivate.Text = "Deactivate";
            }
        }

        // Helper method to safely get cell values
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName]?.Value != null)
                return row.Cells[columnName].Value.ToString();
            return "-";
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
            LoadUserStatistics();
            txtSearch.Clear();
            cmbFilter.SelectedIndex = 0;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void FormatDataGridView()
        {
            // Hide UserID column if it exists
            if (guna2DataGridView1.Columns.Contains("UserID"))
                guna2DataGridView1.Columns["UserID"].Visible = false;

            // Set column widths
            if (guna2DataGridView1.Columns.Contains("Username"))
                guna2DataGridView1.Columns["Username"].Width = 150;

            if (guna2DataGridView1.Columns.Contains("Role"))
                guna2DataGridView1.Columns["Role"].Width = 120;

            if (guna2DataGridView1.Columns.Contains("FullName"))
                guna2DataGridView1.Columns["FullName"].Width = 200;

            if (guna2DataGridView1.Columns.Contains("LoginTime"))
                guna2DataGridView1.Columns["LoginTime"].Width = 180;

            if (guna2DataGridView1.Columns.Contains("Status"))
                guna2DataGridView1.Columns["Status"].Width = 80;

            // Color coding for status
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["Status"]?.Value?.ToString() == "Active")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                }
            }
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
                    string todayQuery = "SELECT COUNT(*) FROM Users WHERE CAST(LastLoginTime AS DATE) = CAST(GETDATE() AS DATE) AND LastLoginTime IS NOT NULL";
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is in the process of development");
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string username = lblUsernameValue.Text;
                MessageBox.Show($"Edit user {username} - This feature is in development");
            }
            else
            {
                MessageBox.Show("Please select a user to edit");
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string username = lblUsernameValue.Text;
                string action = btnDeactivate.Text;
                MessageBox.Show($"{action} user {username} - This feature is in development");
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string username = lblUsernameValue.Text;
                MessageBox.Show($"Reset password for {username} - This feature is in development");
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }
    }
}