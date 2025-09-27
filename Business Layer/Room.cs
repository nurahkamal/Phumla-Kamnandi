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
        private int _roomID;
        private int _HID;
        private string _roomNum; //Musnt this be a int ? On table it shows VarChar
        private string _roomType;//Do we need a room type
        private int _MaxOcc;
        private string _roomStatus;
        #endregion

        #region Property Methods

        public int RoomID
        { get { return _roomID; } set { _roomID = value; }}

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

        public Room() 
        {
            _roomID = 0; 
            _HID = 0;
            _roomNum = ""; //need to chaneg to ) if number
            _roomType = ""; 
            _MaxOcc = 0;
            _roomStatus = ""; 

        }

        public Room ( int Rid , int Hid , string RNum ,string Rtype , int RMax , string Rstatus)
        {
            _roomID = Rid; 
            _HID = Hid;
            _roomNum = RNum;
            _roomType = Rtype;
            _MaxOcc = RMax;
            _roomStatus = Rstatus;
        }
        #endregion



    }
}
