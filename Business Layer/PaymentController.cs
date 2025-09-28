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
        public void DisplayPaymentDetails(System.Windows.Forms.RichTextBox richTextBox, Payment payment)
        {
            richTextBox.Clear();
            richTextBox.AppendText($"Reservation ID: {payment.ReservationID}\n");
            richTextBox.AppendText($"Account ID: {payment.AccountID}\n");
            richTextBox.AppendText($"Payment Date: {payment.PaymentDate:d}\n");
            richTextBox.AppendText($"Payment Type: {payment.PaymentType}\n");
            richTextBox.AppendText($"Total Amount: {payment.TotalAmount:C}\n");
            richTextBox.AppendText($"Deposit (10%): {payment.Deposit:C}\n");
            richTextBox.AppendText($"Amount Paid: {payment.AmountPaid:C}\n");
        }

        // Save payment
        public void SavePayment(Payment payment)
        {
            paymentDB.AddPayment(payment);
        }
    }
}
