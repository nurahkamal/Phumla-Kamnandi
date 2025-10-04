using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    internal class ReservationController
    {
        private ReservationDB reservationDB = new ReservationDB();
        private RoomController roomController = new RoomController(); 
        private RoomDB roomDB = new RoomDB();

        // Create a reservation for a guest
        public int CreateReservation(int guestID, int numberOfGuests, DateTime checkIn, DateTime checkOut, int requestedRooms)
        {
            // Calculate minimum rooms required (max 4 guests per room)
            int minRoomsRequired = (int)Math.Ceiling(numberOfGuests / 4.0);

            // Use the greater of requestedRooms or minimum required
            int numberOfRooms = Math.Max(requestedRooms, minRoomsRequired);

            // Get the room rate based on check-in date
            decimal roomRate = RoomController.GetRoomRate(checkIn);

            // Get a list of available rooms for the requested dates
            List<int> availableRooms = roomDB.GetAvailableRooms(checkIn, checkOut, numberOfRooms);

            // If there are not enough rooms available, throw an exception
            if (availableRooms.Count < numberOfRooms)
                throw new Exception("Not enough rooms available.");

            // Insert the reservation into the database and return the generated reservationID
            int reservationID = reservationDB.InsertReservation(guestID, numberOfGuests, checkIn, checkOut, availableRooms, roomRate);

            return reservationID;
        }
    }

}


