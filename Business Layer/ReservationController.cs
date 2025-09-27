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
        private RoomDB roomDB = new RoomDB();

       
        public static decimal GetRoomRate(DateTime checkInDate)
        {
            if (checkInDate.Day >= 1 && checkInDate.Day <= 7)      // Low Season
                return 550;
            else if (checkInDate.Day >= 8 && checkInDate.Day <= 15) // Mid Season
                return 750;
            else                                                     // High Season
                return 995;
        }

        public bool IsFullyBooked(DateTime checkIn, DateTime checkOut, int requestedRooms)
        {
            return roomDB.IsFullyBooked(checkIn, checkOut, requestedRooms);
        }

        
        public void CreateReservation(int guestID, int numberOfGuests, DateTime checkIn, DateTime checkOut)
        {
            int numberOfRooms = (int)Math.Ceiling(numberOfGuests / 4.0);
            decimal roomRate = GetRoomRate(checkIn);

         
            List<int> availableRooms = roomDB.GetAvailableRooms(checkIn, checkOut, numberOfRooms);
            if (availableRooms.Count < numberOfRooms)
                throw new Exception("Not enough rooms available.");

          
            reservationDB.InsertReservationWithRoomsAndAllocation(guestID, numberOfGuests, checkIn, checkOut, availableRooms, roomRate);
        }
    }

}
