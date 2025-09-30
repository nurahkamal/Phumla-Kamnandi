using Microsoft.VisualBasic;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Phumla_Kamnandi.Data_Layer
{
    public class GuestDB
    { //Connection String 
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";
        #region Utility Methods

        // Gets Guest List 

        public DataTable SeeGuests()
        {
            DataTable guestsTable = new DataTable();

           using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.Guests";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(guestsTable); // Data Table gets filled 
            }

            return guestsTable; // Guest Table is returned 
        }

        //

        #endregion 






    }
}
