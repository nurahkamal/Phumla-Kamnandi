using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    internal class ReservationDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        public void InsertReservationWithRoomsAndAllocation(int guestID, int numberOfGuests, DateTime checkIn, DateTime checkOut, List<int> roomIDs, decimal roomRate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1️⃣ Insert into Reservations
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

                int reservationID = Convert.ToInt32(cmdRes.ExecuteScalar());

                // 2️⃣ Insert into ReservationRooms and RoomAllocation
                for (int i = 0; i < roomIDs.Count; i++)
                {
                    int guestsInRoom = (i == roomIDs.Count - 1) ? (numberOfGuests - i * 4) : 4;
                    int roomID = roomIDs[i];

                    // ReservationRooms
                    string roomQuery = @"INSERT INTO ReservationRooms (ReservationID, RoomID, RateApplied, DiscountApplied, NumberOfGuests)
                                     VALUES (@ResID, @RoomID, @Rate, 0, @GuestsInRoom)";
                    SqlCommand cmdRoom = new SqlCommand(roomQuery, connection);
                    cmdRoom.Parameters.AddWithValue("@ResID", reservationID);
                    cmdRoom.Parameters.AddWithValue("@RoomID", roomID);
                    cmdRoom.Parameters.AddWithValue("@Rate", roomRate);
                    cmdRoom.Parameters.AddWithValue("@GuestsInRoom", guestsInRoom);
                    cmdRoom.ExecuteNonQuery();

                    // RoomAllocation for each night
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
                }
            }
        }
    }

}
