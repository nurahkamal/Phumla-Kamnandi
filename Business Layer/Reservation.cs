using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class Reservation
    {
        #region Data Members
        private int _reservationID;
        private int _guestID;
        private DateTime _checkInDate;
        private DateTime _checkOutDate;
        private int _numberOfRooms;
        private decimal _roomRate;
        #endregion

        #region Property Methods
        public int ReservationID
        {
            get { return _reservationID; }
            set { _reservationID = value; }
        }

        public int GuestID
        {
            get { return _guestID; }
            set { _guestID = value; }
        }

        public DateTime CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        public DateTime CheckOutDate
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set { _numberOfRooms = value; }
        }

        public decimal RoomRate
        {
            get { return _roomRate; }
            set { _roomRate = value; }
        }
        #endregion

        #region Constructors
        public Reservation()
        {
            _reservationID = 0;
            _guestID = 0;
            _checkInDate = DateTime.Today;
            _checkOutDate = DateTime.Today;
            _numberOfRooms = 0;
            _roomRate = 0.0m;
        }

        public Reservation(int reservationID, int guestID, DateTime checkInDate, DateTime checkOutDate, int numberOfRooms, decimal roomRate)
        {
            _reservationID = reservationID;
            _guestID = guestID;
            _checkInDate = checkInDate;
            _checkOutDate = checkOutDate;
            _numberOfRooms = numberOfRooms;
            _roomRate = roomRate;
        }
        #endregion
    }
}
