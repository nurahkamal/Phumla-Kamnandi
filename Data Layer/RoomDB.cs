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

                SqlCommand totalRoomsCmd = new SqlCommand("SELECT COUNT(*) FROM Rooms", connection); // Get total number of rooms in the hotel
                int totalRooms = (int)totalRoomsCmd.ExecuteScalar();

                // Count how many rooms are already reserved during the requested dates
                string reservedQuery = @"SELECT COUNT(rr.ReservationRoomID)
                                 FROM Reservations r
                                 INNER JOIN ReservationRooms rr ON r.ReservationID = rr.ReservationID
                                 WHERE r.CheckInDate < @CheckOutDate
                                 AND r.CheckOutDate > @CheckInDate";

                SqlCommand reservedCmd = new SqlCommand(reservedQuery, connection);
                reservedCmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                reservedCmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                int reservedRooms = (int)reservedCmd.ExecuteScalar();

                // Check if adding the requested rooms exceeds total available rooms
                return (reservedRooms + requestedRooms) > totalRooms;
            }
        }

        // Get a list of available room IDs between two dates(Assigning rooms to reservation)
        public List<int> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int requestedRooms)
        {
            List<int> rooms = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve all room IDs from the database
                SqlCommand allRoomsCmd = new SqlCommand("SELECT RoomID FROM Rooms", connection);
                SqlDataReader reader = allRoomsCmd.ExecuteReader();
                List<int> allRooms = new List<int>();
                while (reader.Read())
                    allRooms.Add(reader.GetInt32(0));
                reader.Close();

              // Retrieve all occupied rooms within the requested date range
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

                rooms = allRooms.Except(occupiedRooms).Take(requestedRooms).ToList(); // Get the list of rooms that are not occupied and limit to requestedRooms count
            }

            return rooms;
        }
    }




}

