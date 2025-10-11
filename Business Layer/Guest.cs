using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phumla_Kamnandi.Business_Layer
{
   public class Guest:Persons
    {
        #region Data Members 
        private int _GID;
       
        private int _loyaltyPoints;
        #endregion



        #region Property Methods 
        public int Gid
        {
            get { return _GID;  }
            set { _GID = value; }

        }

        public int loyaltyPoints 
        {   get { return _loyaltyPoints; } 
            set {_loyaltyPoints = value; }
        }

        #endregion

        #region Methods

       

        #endregion
        #region Constructors 

        public Guest ()
        {
            _loyaltyPoints = 0;
        }

        public Guest (string name, string lastname, string PhoneNo, string id, string address, string email, int GuestID ,  int LoyaltyPoints) 
            :base (name, lastname, PhoneNo, id, address, email)
        {

            _GID = GuestID;
            _loyaltyPoints = LoyaltyPoints;
        }
        #endregion
    }

}
