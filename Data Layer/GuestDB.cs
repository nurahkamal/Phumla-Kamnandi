using Microsoft.VisualBasic;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Phumla_Kamnandi.Data_Layer
{
    public class GuestDB : DB
    {
        private string gtableName = "dbo.Guests";
        protected string stringConn = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";
        #region Utility Methods

        // Gets Guest List 

        public DataTable GetAllGuests()
        {
            FillDataSet("SELECT * FROM dbo.Guests", gtableName);
            return dsMain.Tables[gtableName];
        }
        public bool GuestExists(int guestID)
        {
            using (SqlConnection conn = new SqlConnection(stringConn))
            {
                string query = "SELECT COUNT(*) FROM Guests WHERE GuestID = @GuestID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GuestID", guestID);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // true if guest exists
            }
        }

        public bool UpdateGuest(string gID, string guestName, string gLastName, string gPhone, string gEmail, string pID,  string gAddress, int lPoints)
        {
            try
            {
                FillDataSet("SELECT * FROM dbo.Guests", gtableName);
                DataRow[] rows = dsMain.Tables[gtableName].Select($"GuestID = {gID}");
                if (rows.Length == 0)
                {
                    MessageBox.Show("Guest not found.");
                    return false;
                }

                DataRow row = rows[0];

                // Step 3: Update the values in memory
                row["FirstName"] = guestName;
                row["LastName"] = gLastName;
                row["Phone"] = gPhone;
                row["Email"] = gEmail;
                row["IDNumber"] = pID;
                row["Address"] = gAddress;
                row["LoyaltyPoints"] = lPoints; 


                return UpdateDataSource("SELECT * FROM dbo.Guests", gtableName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error updating guest: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        

        // Delete a guest and all related records
        public void DeleteGuest(string guestId)
        {
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int affectedRows = 0;

                        // Delete order:
                        var deleteQueries = new List<string>
                {
                    // 1. Delete Payments linked via Accounts and  Reservations and Guest
                    "DELETE FROM dbo.Payments WHERE AccountID IN " +
                    "(SELECT AccountID FROM dbo.Accounts WHERE ReservationID IN " +
                    "(SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId))",

                    // 2. Delete Room Allocations linked to Reservations
                    "DELETE FROM dbo.RoomAllocation WHERE ReservationID IN " +
                    "(SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId)",

                    // 3. Delete Accounts linked to Reservations
                    "DELETE FROM dbo.Accounts WHERE ReservationID IN " +
                    "(SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId)",

                    // 4. Delete ReservationRooms links
                    "DELETE FROM dbo.ReservationRooms WHERE ReservationID IN " +
                    "(SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId)",

                    // 5. Delete Reservations
                    "DELETE FROM dbo.Reservations WHERE GuestID = @GuestId",

                    // 6. Delete the Guest
                    "DELETE FROM dbo.Guests WHERE GuestID = @GuestId"
                };

                        // Execute all delete statements inside the transaction
                        foreach (var query in deleteQueries)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@GuestId", guestId);
                                int rows = cmd.ExecuteNonQuery();
                                affectedRows += rows;
                            }
                        }

                        if (affectedRows == 0)
                        {
                            // No related rows were found — rollback
                            transaction.Rollback();
                            MessageBox.Show("No related records were deleted. Operation cancelled.",
                                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Everything successful — commit
                            transaction.Commit();
                            
                            MessageBox.Show("Guest Deleted Successfully ", "Deleted Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Full rollback on any error
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while deleting the guest: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion



    }


}


