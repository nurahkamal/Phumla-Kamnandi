using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    
    public class Person
    {
        #region Data Members
        // Peson Characteristics 

        private string _Pname;
        private  string _Psurname;
        private string _Pid;
        private string _Ppass;
        private string _Pphone ; // can't be string otherwise 0 will be dropped 
        private string _Pemail;
        private string _Paddress;

        #endregion

        #region Property Methods
        
        public string Pname
        {
            get { return _Pname;  }
            set { _Pname = value; }

        }

        public string Psurname
        {
            get { return _Psurname; }
            set { _Psurname = value; }

        }

        public string Pid
        {
            get { return _Pid; }
            set { _Pid = value; }
        }

        public string Ppass
        {
            get { return _Ppass; }
            set { _Ppass = value; }
        }
            
        public string Pphone
        {
            get { return _Pphone; }
            set { _Pphone = value; }


        }

        public string Pemail
        {
            get { return _Pemail; }
            set { _Pemail = value; }
        }

        public string Paddress
        { 
            get { return _Paddress; }
            set { _Paddress = value; }
        }



        #endregion


        #region Constructors 

        public Person ( )
        {

         _Pname = "";
         _Psurname = "";
         _Pid = "";
        _Ppass = "";
        _Pphone =""; 
       _Pemail = "";
        _Paddress ="";

    }

        public Person (string PName , string PSurname , string PID , string PPass , string PPhone , string PEmail, string PADDRESS)
        {
            _Pname = PName ;
            _Psurname = PSurname;
            _Pid = PID;
            _Ppass = PPass;
            _Pphone = PPhone;
            _Pemail = PEmail;

        }
        #endregion




    }
}
