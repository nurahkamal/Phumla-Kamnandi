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

        public void AddPaymentAndAccount(Payment payment, Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string loyaltyQuery = "SELECT LoyaltyPoints FROM Guests WHERE GuestID = @GuestID";
                SqlCommand cmdLoyalty = new SqlCommand(loyaltyQuery, conn);
                cmdLoyalty.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                object result = cmdLoyalty.ExecuteScalar();
                int loyaltyPoints = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                // Step 2: Apply discount if loyalty points >= 5
                if (loyaltyPoints >= 5)
                {
                    decimal discount = 100; // R100
                    payment.TotalAmount = payment.TotalAmount - discount;
                    payment.Balance = payment.TotalAmount - payment.AmountPaid;

                    // Reset loyalty points
                    string resetQuery = "UPDATE Guests SET LoyaltyPoints = 0 WHERE GuestID = @GuestID";
                    SqlCommand resetCmd = new SqlCommand(resetQuery, conn);
                    resetCmd.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                    resetCmd.ExecuteNonQuery();
                }

                // Insert into Accounts table 
                string accountSql = @"INSERT INTO Accounts (ReservationID, Status, TotalAmount, Balance)
                              VALUES (@ReservationID, @Status, @TotalAmount, @Balance);
                              SELECT SCOPE_IDENTITY();";

                int accountID;
                using (SqlCommand cmdAcc = new SqlCommand(accountSql, conn))
                {
                    cmdAcc.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
                    cmdAcc.Parameters.AddWithValue("@Status", payment.Status);
                    cmdAcc.Parameters.AddWithValue("@TotalAmount", payment.TotalAmount);
                    cmdAcc.Parameters.AddWithValue("@Balance", payment.Balance);

                    accountID = Convert.ToInt32(cmdAcc.ExecuteScalar()); // get generated AccountID
                }

                // Insert into Payments
                string paymentSql = @"INSERT INTO Payments (AccountID, PaymentDate, PaymentType, AmountPaid) 
                              VALUES (@AccountID, @PaymentDate, @PaymentType, @AmountPaid)";
                using (SqlCommand cmd = new SqlCommand(paymentSql, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountID", accountID);
                    cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    cmd.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
                    cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddAccount(Payment payment, Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string loyaltyQuery = "SELECT LoyaltyPoints FROM Guests WHERE GuestID = @GuestID";
                SqlCommand cmdLoyalty = new SqlCommand(loyaltyQuery, conn);
                cmdLoyalty.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                object result = cmdLoyalty.ExecuteScalar();
                int loyaltyPoints = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                // Apply discount if loyalty points >= 5
                if (loyaltyPoints >= 5)
                {
                    decimal discount = 100; //R100
                    payment.TotalAmount = payment.TotalAmount - discount;

                    // Reset loyalty points
                    string resetQuery = "UPDATE Guests SET LoyaltyPoints = 0 WHERE GuestID = @GuestID";
                    SqlCommand resetCmd = new SqlCommand(resetQuery, conn);
                    resetCmd.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                    resetCmd.ExecuteNonQuery();
                }

                // Insert into Accounts table 
                string accountSql = @"INSERT INTO Accounts (ReservationID, Status, TotalAmount, Balance)
                              VALUES (@ReservationID, @Status, @TotalAmount, @Balance);
                              SELECT SCOPE_IDENTITY();";

                int newAccountId;
                using (SqlCommand cmdAcc = new SqlCommand(accountSql, conn))
                {
                    cmdAcc.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
                    cmdAcc.Parameters.AddWithValue("@Status", payment.Status);
                    cmdAcc.Parameters.AddWithValue("@TotalAmount", payment.TotalAmount);
                    cmdAcc.Parameters.AddWithValue("@Balance", payment.TotalAmount);

                    newAccountId = Convert.ToInt32(cmdAcc.ExecuteScalar());
                }

                string updateReservationSql = @"UPDATE Reservations
                                                SET PaymentStatus = @PaymentStatus
                                                WHERE ReservationID = @ReservationID";

                using (SqlCommand cmdUpdate = new SqlCommand(updateReservationSql, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@PaymentStatus", "Outstanding"); // or whatever status you need
                    cmdUpdate.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);

                    cmdUpdate.ExecuteNonQuery();
                }





            }


        }

    }
}
