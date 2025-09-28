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

                // Insert into Payments table
                string paymentSql = @"INSERT INTO Payments (AccountID, ReservationID, PaymentDate, PaymentType, AmountPaid) 
                              VALUES (@AccountID, @ReservationID, @PaymentDate, @PaymentType, @AmountPaid)";
                using (SqlCommand cmd = new SqlCommand(paymentSql, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountID", payment.AccountID);
                    cmd.Parameters.AddWithValue("@ReservationID", payment.ReservationID);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
                    cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                    cmd.ExecuteNonQuery();
                }

                // Insert into Accounts table
                string accountSql = @"INSERT INTO Accounts (ReservationID, Status, TotalAmount, Balance) 
                              VALUES (@ReservationID, @Status, @TotalAmount, @Balance)";
                using (SqlCommand cmdAcc = new SqlCommand(accountSql, conn))
                {
                    cmdAcc.Parameters.AddWithValue("@ReservationID", payment.ReservationID);
                    cmdAcc.Parameters.AddWithValue("@Status", payment.Status);
                    cmdAcc.Parameters.AddWithValue("@TotalAmount", payment.TotalAmount);
                    cmdAcc.Parameters.AddWithValue("@Balance", payment.Balance);
                    cmdAcc.ExecuteNonQuery();
                }
            }
        }
    }
}
