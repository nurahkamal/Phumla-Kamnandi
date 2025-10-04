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

        public bool UpdateGuest(string gID, string guestName, string gLastName, string gPhone, string gEmail, string pID, string gPassNum, string gAddress)
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
                row["PassportNo"] = gPassNum;
                row["Address"] = gAddress;

                return UpdateDataSource("SELECT * FROM dbo.Guests", gtableName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error updating guest: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //Delete a guest 

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

                        // Queries in the correct delete order (Payments → Accounts → Reservation_Room → Reservations → Guest)
                        var deleteQueries = new List<string>
                {

                    // Step 1: Delete payments linked via accounts
                    "DELETE FROM dbo.Payments WHERE AccountID IN (SELECT AccountID FROM dbo.Accounts WHERE ReservationID IN (SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId))",

                    "DELETE FROM dbo.RoomAllocation WHERE ReservationID  IN (SELECT AccountID FROM dbo.Accounts WHERE ReservationID IN (SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId))",

                    // Step 2: Delete accounts linked to reservations
                    "DELETE FROM dbo.Accounts WHERE ReservationID IN (SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId)",

                    // Step 3: Delete reservation-room links
                    "DELETE FROM dbo.ReservationRooms WHERE ReservationID IN (SELECT ReservationID FROM dbo.Reservations WHERE GuestID = @GuestId)",

                    // Step 4: Delete reservations
                    "DELETE FROM dbo.Reservations WHERE GuestID = @GuestId",

                    // Step 5: Delete guest
                    "DELETE FROM dbo.Guests WHERE GuestID = @GuestId"
                };

                        // Execute each query
                        foreach (var query in deleteQueries)
                        {
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@GuestId", guestId);
                                affectedRows += command.ExecuteNonQuery();
                            }
                        }

                        // Commit transaction if successful
                        transaction.Commit();


                    }
                    catch (Exception ex)
                    {
                        // Roll back if something fails
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


