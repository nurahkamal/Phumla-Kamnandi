using Microsoft.VisualBasic;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Phumla_Kamnandi.Data_Layer
{
    public class GuestDB : DB
    { // Insert Connection String private string ConnectionString =

        #region DataMembers
        private string table1 = "Guests";
        private string sqlLocal1 = "SELECT * FROM Guests";
        private Collection<Guest> guests;



        #endregion

        #region Property Methods

        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }

        #endregion
        #region Constructor 
       public GuestDB(): base() 
        {
            guests = new Collection<Guest>();
            FillDataSet(sqlLocal1, table1);
            //Add2Collection(table1);
            



        }





        #endregion

        #region Utility Methods

        // Gets all guests 
        public DataSet GetDataSet()
        {
            return dsMain;
        }




        #endregion


    }
}
