using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phumla_Kamnandi.Business_Layer
{
    public  class TravelAgent:Persons
    {
        #region Data Members
        private int _aID; 
        private string  _agencyName;



        #endregion

        #region Property Methods

        public int aID
        {
            get { return _aID; }
            set { _aID = value; }

        }

        public string agencyName
        {
            get { return _agencyName; }
            set { _agencyName = value; }

        }

        #endregion

        #region Constructors

        public TravelAgent()
        {

            
            _agencyName= "";
            

        }


        public TravelAgent(string PName, string AName)
        { 
            _agencyName = PName;
            

        }
        #endregion


    }
}
