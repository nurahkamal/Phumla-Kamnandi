using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kamnandi.Data_Layer;

namespace Phumla_Kamnandi.Business_Layer
{
    internal class RoomController
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
    }
}
