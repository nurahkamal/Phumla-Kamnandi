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
        public int CreateReservation(int guestID, int numberOfGuests, DateTime checkIn, DateTime checkOut)
        {

            
            int numberOfRooms = (int)Math.Ceiling(numberOfGuests / 4.0);  // Calculate the number of rooms required (max 4 guests per room)
            decimal roomRate = RoomController.GetRoomRate(checkIn);       // Get the room rate based on the check-in date

            List<int> availableRooms = roomDB.GetAvailableRooms(checkIn, checkOut, numberOfRooms); // Get a list of available rooms for the requested dates
            if (availableRooms.Count < numberOfRooms)   // If there are not enough rooms available, throw an exception
                throw new Exception("Not enough rooms available.");

            // Return the reservationID from DB and insert into DB
            int reservationID = reservationDB.InsertReservation(guestID, numberOfGuests, checkIn, checkOut, availableRooms, roomRate);

            return reservationID;
        }

    }

}
