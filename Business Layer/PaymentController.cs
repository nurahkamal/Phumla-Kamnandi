using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    internal class PaymentController
    {
        private PaymentDB paymentDB = new PaymentDB(); // Instance of the PaymentDB class to interact with the database

        // Calculate total based on number of rooms and days
        public decimal CalculateTotal(decimal roomPrice, int numberOfRooms, int numberOfDays)
        {
            return roomPrice * numberOfRooms * numberOfDays;
        }

        // Calculate 10% deposit
        public decimal CalculateDeposit(decimal total)
        {
            return total * 0.10m;
        }

        // Display payment details in RichTextBox
        public void DisplayPaymentDetails(System.Windows.Forms.RichTextBox richTextBox, Payment payment, Reservation reservation)
        {
            richTextBox.Clear();
            richTextBox.AppendText($"Reservation ID: {payment.ReservationID}\n\n");
            richTextBox.AppendText($"Check-In Date: {reservation.CheckInDate:d}\n");
            richTextBox.AppendText($"Check-Out Date: {reservation.CheckOutDate:d}\n");
            int numberOfDays = (reservation.CheckOutDate - reservation.CheckInDate).Days;
            richTextBox.AppendText($"Number of Days: {numberOfDays}\n");
            richTextBox.AppendText($"Number of Rooms: {reservation.NumberOfRooms}\n");
            richTextBox.AppendText($"Room Rate: {reservation.RoomRate:C}\n\n");
            richTextBox.AppendText($"Total Amount: {payment.TotalAmount:C}\n");
            richTextBox.AppendText($"Deposit (10%): {payment.Deposit:C}\n\n");

            // Fetch Loyalty Points from Guests table
            int loyaltyPoints = 0;
            // Open a connection to the database and retrieve the loyalty points 
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True"))
            {
                conn.Open(); // Open the SQL database connection
                string query = "SELECT LoyaltyPoints FROM Guests WHERE GuestID = @GuestID";
                SqlCommand cmd = new SqlCommand(query, conn); // Create a SQL command with the query and connection
                cmd.Parameters.AddWithValue("@GuestID", reservation.GuestID);

                object result = cmd.ExecuteScalar(); // Execute the query and retrieve the single value (LoyaltyPoints)
                loyaltyPoints = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;  // Convert the result to an integer if not null, otherwise default to 0
            }

            // Display loyalty points
            richTextBox.AppendText($"Loyalty Points: {loyaltyPoints}\n");

            // Show Discount if applicable
            if (loyaltyPoints >= 5)
            {
                decimal discount = 100; // R100 discount
                payment.TotalAmount = payment.TotalAmount - discount;
                richTextBox.AppendText($"Loyalty Discount: {discount:C}\n");
                richTextBox.AppendText($"Total After Discount: {payment.TotalAmount:C}\n");
            }
        }

        // Save payment information to the database
        public void SavePayment(Payment payment, Reservation reservation)
        {
            paymentDB.AddPaymentAndAccount(payment, reservation);
        }
    }
}
