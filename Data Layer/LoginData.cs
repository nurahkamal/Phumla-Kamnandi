using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Phumla_Kamnandi.Data_Layer
{
    internal class LoginData
    {
        #region Constructor for connection string

        private string connectionString;
        public LoginData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Method for User Validation 
        public bool ValidateUser(string username, string password)
        {
            string query = $"SELECT COUNT(1) FROM Login WHERE Username = '{username}' AND PasswordHash = '{password}'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count == 1;
                }

            }
        }
        #endregion

        #region Method to get user role in order to authorize login 
        public string GetUserRole (string username)
        {
            string query = "SELECT Role FROM Staff WHERE Username = @Username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    return result?.ToString() ?? string.Empty;


                }
            }
        }
        #endregion

        #region Method to get the staffs name and lastname
        public (string FirstName, string LastName) GetStaffName(string username)
        {
            string query = "SELECT FirstName, LastName FROM Staff WHERE Username = @Username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            return (firstName, lastName);
                        }
                        
                    }
                }
            }
            return (string.Empty, string.Empty);

        }
        #endregion


    }
}
