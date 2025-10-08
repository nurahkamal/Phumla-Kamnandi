using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Data_Layer
{
    public class ReservationDB:DB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";
        private string rtable = "dbo.Reservations";


        //Gets Reservation Table
        public DataTable GetAllReservations()
        {
            FillDataSet("SELECT * FROM dbo.Reservations", rtable);
            return dsMain.Tables[rtable];
        }

        //Update a reservation 

        public bool UpdateReservation(
    int reservationID,
    int newNumberOfGuests,
    DateTime newCheckIn,
    DateTime newCheckOut,
    List<int> newRoomIDs,
    decimal newRoomRate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1️⃣ Update main reservation details
                    string updateResQuery = @"
                UPDATE Reservations
                SET NumberOfGuests = @NumGuests,
                    CheckInDate = @CheckIn,
                    CheckOutDate = @CheckOut,
                    ReservationDate = @UpdateDate
                WHERE ReservationID = @ResID";

                    SqlCommand cmdUpdateRes = new SqlCommand(updateResQuery, connection, transaction);
                    cmdUpdateRes.Parameters.AddWithValue("@NumGuests", newNumberOfGuests);
                    cmdUpdateRes.Parameters.AddWithValue("@CheckIn", newCheckIn);
                    cmdUpdateRes.Parameters.AddWithValue("@CheckOut", newCheckOut);
                    cmdUpdateRes.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                    cmdUpdateRes.Parameters.AddWithValue("@ResID", reservationID);
                    cmdUpdateRes.ExecuteNonQuery();

                    // 2️⃣ Delete old room allocations
                    string deleteRoomsQuery = "DELETE FROM ReservationRooms WHERE ReservationID = @ResID";
                    SqlCommand cmdDelRooms = new SqlCommand(deleteRoomsQuery, connection, transaction);
                    cmdDelRooms.Parameters.AddWithValue("@ResID", reservationID);
                    cmdDelRooms.ExecuteNonQuery();

                    string deleteAllocQuery = "DELETE FROM RoomAllocation WHERE ReservationID = @ResID";
                    SqlCommand cmdDelAlloc = new SqlCommand(deleteAllocQuery, connection, transaction);
                    cmdDelAlloc.Parameters.AddWithValue("@ResID", reservationID);
                    cmdDelAlloc.ExecuteNonQuery();

                    // 3️⃣ Reinsert new rooms and allocations
                    int remainingGuests = newNumberOfGuests;
                    for (int i = 0; i < newRoomIDs.Count; i++)
                    {
                        int roomsLeft = newRoomIDs.Count - i;
                        int guestsInRoom = Math.Max(1, (int)Math.Ceiling((double)remainingGuests / roomsLeft));
                        int roomID = newRoomIDs[i];

                        // Insert into ReservationRooms
                        string insertRoomQuery = @"
                    INSERT INTO ReservationRooms (ReservationID, RoomID, RateApplied, DiscountApplied, NumberOfGuests)
                    VALUES (@ResID, @RoomID, @Rate, 0, @GuestsInRoom)";
                        SqlCommand cmdRoom = new SqlCommand(insertRoomQuery, connection, transaction);
                        cmdRoom.Parameters.AddWithValue("@ResID", reservationID);
                        cmdRoom.Parameters.AddWithValue("@RoomID", roomID);
                        cmdRoom.Parameters.AddWithValue("@Rate", newRoomRate);
                        cmdRoom.Parameters.AddWithValue("@GuestsInRoom", guestsInRoom);
                        cmdRoom.ExecuteNonQuery();

                        // Allocate room per day
                        for (DateTime day = newCheckIn; day < newCheckOut; day = day.AddDays(1))
                        {
                            string allocQuery = @"
                        INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID)
                        VALUES (@RoomID, @Date, @ResID)";
                            SqlCommand cmdAlloc = new SqlCommand(allocQuery, connection, transaction);
                            cmdAlloc.Parameters.AddWithValue("@RoomID", roomID);
                            cmdAlloc.Parameters.AddWithValue("@Date", day);
                            cmdAlloc.Parameters.AddWithValue("@ResID", reservationID);
                            cmdAlloc.ExecuteNonQuery();
                        }

                        remainingGuests -= guestsInRoom;
                    }

                    // 4️⃣ Recalculate total payment based on rooms and nights
                    decimal totalNights = (decimal)(newCheckOut - newCheckIn).TotalDays;
                    decimal totalPrice = totalNights * newRoomRate * newRoomIDs.Count;

                    // 5️⃣ Update Accounts table to reflect new TotalAmount and correct Balance
                    string updateAccountQuery = @"
                UPDATE Accounts
                SET TotalAmount = @NewTotal,
                    Balance = @NewTotal - ISNULL(
                                  (SELECT SUM(AmountPaid)
                                   FROM Payments
                                   WHERE AccountID = Accounts.AccountID), 0)
                WHERE ReservationID = @ResID";

                    SqlCommand cmdAccount = new SqlCommand(updateAccountQuery, connection, transaction);
                    cmdAccount.Parameters.AddWithValue("@NewTotal", totalPrice);
                    cmdAccount.Parameters.AddWithValue("@ResID", reservationID);
                    cmdAccount.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error updating reservation: " + ex.Message);
                    return false;
                }
            }
        }
        //Deletes ReservationID
        public bool DeleteReservation(string reservationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Step 1: Delete payments linked via accounts
                    string deletePaymentsQuery = @"
                DELETE FROM Payments
                WHERE AccountID IN (
                    SELECT AccountID FROM Accounts WHERE ReservationID = @ResID
                )";
                    using (SqlCommand cmdPayments = new SqlCommand(deletePaymentsQuery, connection, transaction))
                    {
                        cmdPayments.Parameters.AddWithValue("@ResID", reservationID);
                        cmdPayments.ExecuteNonQuery();
                    }

                    // Step 2: Delete accounts linked to this reservation
                    string deleteAccountsQuery = @"DELETE FROM Accounts WHERE ReservationID = @ResID";
                    using (SqlCommand cmdAccounts = new SqlCommand(deleteAccountsQuery, connection, transaction))
                    {
                        cmdAccounts.Parameters.AddWithValue("@ResID", reservationID);
                        cmdAccounts.ExecuteNonQuery();
                    }

                    // Step 3: Delete room allocations
                    string deleteAllocQuery = @"DELETE FROM RoomAllocation WHERE ReservationID = @ResID";
                    using (SqlCommand cmdAlloc = new SqlCommand(deleteAllocQuery, connection, transaction))
                    {
                        cmdAlloc.Parameters.AddWithValue("@ResID", reservationID);
                        cmdAlloc.ExecuteNonQuery();
                    }

                    // Step 4: Delete room entries
                    string deleteRoomsQuery = @"DELETE FROM ReservationRooms WHERE ReservationID = @ResID";
                    using (SqlCommand cmdRooms = new SqlCommand(deleteRoomsQuery, connection, transaction))
                    {
                        cmdRooms.Parameters.AddWithValue("@ResID", reservationID);
                        cmdRooms.ExecuteNonQuery();
                    }

                    // Step 5: Delete the main reservation
                    string deleteResQuery = @"DELETE FROM Reservations WHERE ReservationID = @ResID";
                    using (SqlCommand cmdRes = new SqlCommand(deleteResQuery, connection, transaction))
                    {
                        cmdRes.Parameters.AddWithValue("@ResID", reservationID);
                        int affectedRows = cmdRes.ExecuteNonQuery();

                        if (affectedRows == 0)
                        {
                            transaction.Rollback();
                            return false; // No reservation found
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error deleting reservation: " + ex.Message);
                    return false;
                }
            }
        }




        // Inserts a new reservation into the database and returns the generated ReservationID
        public int InsertReservation(int guestID, int numberOfGuests, DateTime checkIn, DateTime checkOut, List<int> roomIDs, decimal roomRate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a new DB connection
            {
                connection.Open();

                // Insert reservation details into Reservations table
                string resQuery = @"INSERT INTO Reservations 
                    (GuestID, NumberOfGuests, CheckInDate, CheckOutDate, ReservationDate, BookingStatus, PaymentStatus)
                    VALUES (@GuestID, @NumberOfGuests, @CheckIn, @CheckOut, @ReservationDate, 'Confirmed', 'Paid');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdRes = new SqlCommand(resQuery, connection);
                cmdRes.Parameters.AddWithValue("@GuestID", guestID);
                cmdRes.Parameters.AddWithValue("@NumberOfGuests", numberOfGuests);
                cmdRes.Parameters.AddWithValue("@CheckIn", checkIn);
                cmdRes.Parameters.AddWithValue("@CheckOut", checkOut);
                cmdRes.Parameters.AddWithValue("@ReservationDate", DateTime.Now);

                // Execute query and retrieve the new ReservationID
                int reservationID = Convert.ToInt32(cmdRes.ExecuteScalar());

                // Update loyalty points for the guest
                string loyaltyQuery = @"UPDATE Guests 
                        SET LoyaltyPoints = LoyaltyPoints + 1 
                        WHERE GuestID = @GuestID";

                SqlCommand cmdLoyalty = new SqlCommand(loyaltyQuery, connection);
                cmdLoyalty.Parameters.AddWithValue("@GuestID", guestID);
                cmdLoyalty.ExecuteNonQuery();

                int remainingGuests = numberOfGuests;
                // Allocate rooms for this reservation
                for (int i = 0; i < roomIDs.Count; i++) // Loop through each available room to assign guests and allocate it in the database
                {

                    int roomsLeft = roomIDs.Count - i;           
                    int guestsInRoom = Math.Max(1, (int)Math.Ceiling((double)remainingGuests / roomsLeft)); // Ensure at least 1 guest per remaining room
                    int roomID = roomIDs[i]; //Get the current room ID from the list of available rooms

                    // Insert into ReservationRooms table
                    string roomQuery = @"INSERT INTO ReservationRooms (ReservationID, RoomID, RateApplied, DiscountApplied, NumberOfGuests)
                                     VALUES (@ResID, @RoomID, @Rate, 0, @GuestsInRoom)";
                    SqlCommand cmdRoom = new SqlCommand(roomQuery, connection);
                    cmdRoom.Parameters.AddWithValue("@ResID", reservationID);
                    cmdRoom.Parameters.AddWithValue("@RoomID", roomID);
                    cmdRoom.Parameters.AddWithValue("@Rate", roomRate);
                    cmdRoom.Parameters.AddWithValue("@GuestsInRoom", guestsInRoom);
                    cmdRoom.ExecuteNonQuery();

                    // Allocate the room for each day of the stay
                    for (DateTime day = checkIn; day < checkOut; day = day.AddDays(1))
                    {
                        string allocQuery = @"INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID)
                                          VALUES (@RoomID, @Date, @ResID)";
                        SqlCommand cmdAlloc = new SqlCommand(allocQuery, connection);
                        cmdAlloc.Parameters.AddWithValue("@RoomID", roomID);
                        cmdAlloc.Parameters.AddWithValue("@Date", day);
                        cmdAlloc.Parameters.AddWithValue("@ResID", reservationID);
                        cmdAlloc.ExecuteNonQuery();
                    }

                    remainingGuests -= guestsInRoom; // Update remaining guests
                }

                return reservationID;
            }
        }
    }

}
