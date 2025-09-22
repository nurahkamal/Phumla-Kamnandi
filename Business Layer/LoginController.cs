using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class LoginController
    {
        private LoginData loginData;

        public LoginController (string connectionString)
        {
            loginData = new LoginData(connectionString);
        }

        public bool AuthenticateUser(string usename, string password)
        {
            if (string.IsNullOrEmpty(usename) || string.IsNullOrEmpty(password))
            return false;
            return loginData.ValidateUser(usename, password);

        }
        #region for username and password
        public string GetUserRole(string username)
        {
            return loginData.GetUserRole(username);
        }

        public string GetStaffFullName(string username)
        {
          var details = loginData.GetStaffDetails(username);
            return $"{details.FirstName} {details.LastName}";
        }
        #endregion

        #region Methods
        public bool IsUserAuthorized(string username, string requiredRole)
        {
            string userRole = GetUserRole(username);
            return userRole.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
        }
        #endregion

    }
}
