using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class Room
    {
        #region Data Members 
        private int _roomID; // Private fields storing room data
        private int _HID;
        private string _roomNum; 
        private string _roomType;
        private int _MaxOcc;
        private string _roomStatus;
        #endregion

        #region Property Methods

        public int RoomID         // Accessor and Mutator methods 
        { 
          get { return _roomID; }  // returns the current room ID
          set { _roomID = value; }  // sets a new room ID
        }

        public int HID 
        {
            get { return _HID; }
            set { _HID = value; }
        }

        public string roomNum
        {
            get { return _roomNum; }
            set { _roomNum = value; }
        }

        public string roomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        public int MaxOcc
        {
            get { return _MaxOcc; }
            set { _MaxOcc = value; }
        }

        public string roomStatus
        {
            get { return _roomStatus; }
            set { _roomStatus = value; }
        }
        #endregion


        #region Constructors 

        public Room()  // Default constructor initializes fields with default values
        {
            _roomID = 0; 
            _HID = 0;
            _roomNum = ""; 
            _roomType = ""; 
            _MaxOcc = 0;
            _roomStatus = ""; 

        }

        public Room ( int Rid , int Hid , string RNum ,string Rtype , int RMax , string Rstatus)
        {
            _roomID = Rid; // Parameterized constructor allows setting of all fields 
            _HID = Hid;
            _roomNum = RNum;
            _roomType = Rtype;
            _MaxOcc = RMax;
            _roomStatus = Rstatus;
        }
        #endregion



    }
}
