using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumla_Kamnandi.Data_Layer;

namespace Phumla_Kamnandi.Business_Layer
{
    internal class PaymentController
    {
        private PaymentDB paymentDB = new PaymentDB();

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
        public void DisplayPaymentDetails(System.Windows.Forms.RichTextBox richTextBox, Payment payment, Reservation reservation)//!!!
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
            

        }

        // Save payment
        public void SavePayment(Payment payment, Reservation reservation)
        {
            paymentDB.AddPaymentAndAccount(payment, reservation);
        }
    }
}
