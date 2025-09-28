using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kamnandi.Business_Layer;

namespace Phumla_Kamnandi.Data_Layer
{
    internal class PaymentDB
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True";

        public void AddPayment(Payment payment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Payments (AccountID, ReservationID, PaymentDate, PaymentType, AmountPaid) " +
                             "VALUES (@AccountID, @ReservationID, @PaymentDate, @PaymentType, @AmountPaid)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    cmd.Parameters.AddWithValue("@ReservationID", payment.ReservationID);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
                    cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
