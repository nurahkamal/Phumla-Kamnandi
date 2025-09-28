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
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            _6 form6 = new _6();   // create an instance of Form _8
            form6.Show();          // show Form _8
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Calculate total and deposit
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;
            decimal totalAmount = _reservation.RoomRate * _reservation.NumberOfRooms * numberOfDays;
            decimal deposit = totalAmount * 0.10m;

            // Create Payment object with PaymentType = "Card"
            Payment payment = new Payment
            {
                AccountID = _reservation.GuestID,
                ReservationID = _reservation.ReservationID,
                PaymentDate = DateTime.Today,
                PaymentType = "Card", // All payments are card
                TotalAmount = totalAmount,
                Deposit = deposit,
                AmountPaid = deposit // default initial payment
            };

            // Display details in RichTextBox
            _paymentController.DisplayPaymentDetails(rtbSummary, payment);

        }
    }
}
