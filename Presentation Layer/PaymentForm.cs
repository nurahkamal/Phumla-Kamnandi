using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
using Phumla_Kamnandi.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class PaymentForm : Form
    {

        private Reservation _reservation; // Store the reservation passed from Reservation form
        private PaymentController _paymentController = new PaymentController();

        public PaymentForm(Reservation reservation)
        {
            InitializeComponent();
            _reservation = reservation;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            pnlCard.Hide();
            // Calculate total and deposit
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;
            decimal totalAmount = _reservation.RoomRate * _reservation.NumberOfRooms * numberOfDays;
            decimal deposit = totalAmount * 0.10m;

            
            Payment payment = new Payment
            {
                AccountID = _reservation.GuestID,
                ReservationID = _reservation.ReservationID,
                PaymentDate = DateTime.Today,
                PaymentType = "Card", 
                TotalAmount = totalAmount,
                Deposit = deposit,
                AmountPaid = deposit // default initial payment
            };

            // Display details in RichTextBox
            _paymentController.DisplayPaymentDetails(rtbSummary, payment, _reservation);
            txtPayableAmt.Text = $"R{deposit:F2}";

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Calculate number of days
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;

            // Calculate total, deposit, balance
            decimal totalAmount = _reservation.RoomRate * _reservation.NumberOfRooms * numberOfDays;
            decimal deposit = totalAmount * 0.10m;
            decimal balance = totalAmount - deposit;

            // Create Payment object
            Payment payment = new Payment
            {
                AccountID = _reservation.GuestID,
                ReservationID = _reservation.ReservationID,
                PaymentDate = DateTime.Today,
                PaymentType = "Card",
                TotalAmount = totalAmount,
                Deposit = deposit,
                AmountPaid = deposit,
                Balance = balance,
                Status = "Open"
            };

            // Save to DB
            PaymentDB paymentDB = new PaymentDB();
            paymentDB.AddPaymentAndAccount(payment, _reservation);

            // Optionally display confirmation
            MessageBox.Show("Payment successful");
        }

        private void btnPaymentLater_Click(object sender, EventArgs e)
        {
            // Calculate number of days
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;

            // Calculate total, deposit, balance
            decimal totalAmount = _reservation.RoomRate * _reservation.NumberOfRooms * numberOfDays;
            decimal deposit = totalAmount * 0.10m;
            decimal balance = totalAmount - deposit;

            // Create Payment object
            Payment payment = new Payment
            {
                AccountID = _reservation.GuestID,
                ReservationID = _reservation.ReservationID,
                PaymentDate = DateTime.Today,
                PaymentType = "Card",
                TotalAmount = totalAmount,
                Deposit = deposit,
                AmountPaid = deposit,
                Balance = balance,
                Status = "Open"
            };

            // Save to DB
            PaymentDB paymentDB = new PaymentDB();
            paymentDB.AddAccount(payment, _reservation);

            // Optionally display confirmation
            MessageBox.Show("Account successfully recorded!");

            btnPaymentNow.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlCard.Show();
            btnPaymentNow.Hide();
            


        }
    }
}

