using Microsoft.VisualBasic;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Xml.Linq;

namespace Phumla_Kamnandi.Data_Layer
{
    public class GuestDB
    { //Connection String 
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";
        #region Utility Methods

        // Gets Guest List 

        public DataTable SeeGuests()
        {
            DataTable guestsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.Guests";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(guestsTable); // Data Table gets filled 
            }

            return guestsTable; // Guest Table is returned 
        }


        //Search Guest ID

        public DataTable SearchGid (string gid)
        {
            DataTable guestsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "SELECT * FROM dbo.Guests WHERE GuestID = @guestID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@guestID", gid);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(guestsTable); // Data Table gets filled 
            }

            return guestsTable; // Guest Table is returned 


        }


        //Delete a guest 

        // Delete a guest and all related records
        public void DeleteGuest(string guestId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        //Update a Guest 

        public void UpdateGuest(string gID, string guestName, string gLastName, string gPhone, string gEmail, string pID, string gPassNum, string gAddress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryUpdate = "UPDATE dbo.Guests SET FirstName =@GName , LastName =@lName , Phone =@guestPhone , Email =@guestEmail , IDNumber =@gIDNum, PassportNo =@passNum , Address =@guestAddress WHERE GuestID = @GuestID";


                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {

                    command.Parameters.AddWithValue("@GuestID", gID);
                    command.Parameters.AddWithValue("@GName", guestName );
                    command.Parameters.AddWithValue("@lName", gLastName);
                    command.Parameters.AddWithValue("@guestPhone", gPhone);
                    command.Parameters.AddWithValue("@guestEmail", gEmail);
                    command.Parameters.AddWithValue("@gIDNum", pID);
                    command.Parameters.AddWithValue("@passNum", gPassNum);
                    command.Parameters.AddWithValue("@guestAddress", gAddress);
                   

                    int AffrectedRows = command.ExecuteNonQuery(); 

                    if (AffrectedRows > 0)
                    {
                        MessageBox.Show("Updated Guest Details", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
                }








            }



        }


        //Search GuestID
        public DataTable SearchID(int gIDNum)
        {
            DataTable dataTable = new DataTable();
            string SearchQuery = "Select * FROM dbo.Guests WHERE GuestID = @guestID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(SearchQuery, conn))
            {
                command.Parameters.AddWithValue("@guestID",gIDNum);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

            }
            return dataTable;
        }

        #endregion


    }
}



