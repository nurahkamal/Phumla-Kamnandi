using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class GuestController
    {

        private GuestDB guestDB = new GuestDB();

        #region Constructor 

        public GuestController()
        { 
        
        guestDB = new GuestDB();
        }

        #endregion

        #region Methods

        // Get all guests 

        public DataTable SeeAllGuests()
        {

            return guestDB.SeeGuests();
        }
        #endregion
    }
}
