using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    internal class RoomDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        public bool IsFullyBooked(DateTime checkInDate, DateTime checkOutDate, int requestedRooms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Step 1: Get total rooms in the hotel
                SqlCommand totalRoomsCmd = new SqlCommand("SELECT COUNT(*) FROM Rooms", connection);
                int totalRooms = (int)totalRoomsCmd.ExecuteScalar();

                // Step 2: Get total reserved rooms that overlap with the requested dates
                string reservedQuery = @"SELECT COUNT(rr.ReservationRoomID)
                                 FROM Reservations r
                                 INNER JOIN ReservationRooms rr ON r.ReservationID = rr.ReservationID
                                 WHERE r.BookingStatus = 'Confirmed'
                                 AND r.CheckInDate < @CheckOutDate
                                 AND r.CheckOutDate > @CheckInDate";

                SqlCommand reservedCmd = new SqlCommand(reservedQuery, connection);
                reservedCmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                reservedCmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                int reservedRooms = (int)reservedCmd.ExecuteScalar();

                // Step 3: Fully booked if remaining rooms are less than requested
                return (reservedRooms + requestedRooms) > totalRooms;
            }
        }


        public List<int> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int requestedRooms)
        {
            List<int> rooms = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get all rooms
                SqlCommand allRoomsCmd = new SqlCommand("SELECT RoomID FROM Rooms", connection);
                SqlDataReader reader = allRoomsCmd.ExecuteReader();
                List<int> allRooms = new List<int>();
                while (reader.Read())
                    allRooms.Add(reader.GetInt32(0));
                reader.Close();

                // Get rooms already allocated in the requested period
                string query = @"SELECT DISTINCT RoomID 
                             FROM RoomAllocation
                             WHERE DateAllocated >= @CheckIn AND DateAllocated < @CheckOut";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                cmd.Parameters.AddWithValue("@CheckOut", checkOut);

                reader = cmd.ExecuteReader();
                List<int> occupiedRooms = new List<int>();
                while (reader.Read())
                    occupiedRooms.Add(reader.GetInt32(0));
                reader.Close();

                // Available rooms = all rooms - occupied rooms
                rooms = allRooms.Except(occupiedRooms).Take(requestedRooms).ToList();
            }

            return rooms;
        }
    }




}

