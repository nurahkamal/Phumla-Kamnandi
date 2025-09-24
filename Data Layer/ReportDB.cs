using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    public abstract class ReportDB
    {
        private readonly string connectionString;

        public ReportDB()
        {
            connectionString = "Server=(local); DataBase=PhumlaKamnandiHotelsDB; Integrated Security=SSPI";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
