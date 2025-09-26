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
        private static int newID = 1; //stores new ID 
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


        #endregion
    }

}
