using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
