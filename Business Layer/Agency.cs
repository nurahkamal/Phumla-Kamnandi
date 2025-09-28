using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class Agency:Persons
    {
        #region DataMembers

        private int _Tid;
        private string _TName;
        #endregion


        #region Property Methods

        public int Tid
        {
            get { return _Tid; }
            set { _Tid = value; }
        }

        public string TName
        {
            get { return _TName; }
            set { _TName = value; }
        }

        #endregion
        #region Constructors

        public Agency()
        {

           
            _TName = ""; 
        }

        public Agency ( int TID , string TAName )
        {

            _Tid = TID;
            _TName = TAName;
        }
        #endregion



    }
}
