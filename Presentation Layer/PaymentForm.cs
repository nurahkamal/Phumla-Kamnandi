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
        private PaymentController _paymentController = new PaymentController(); // Controller that handles payment logic

        public PaymentForm(Reservation reservation) // Constructor that accepts a Reservation object from the previous form
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

            // Create a Payment object with initial details
            Payment payment = new Payment
            {
                AccountID = _reservation.GuestID,
                ReservationID = _reservation.ReservationID,
                PaymentDate = DateTime.Today,
                PaymentType = "Card", 
                TotalAmount = totalAmount,
                Deposit = deposit,
                AmountPaid = deposit // initial amount paid is the deposit
            };

            // Display details in RichTextBox
            _paymentController.DisplayPaymentDetails(rtbSummary, payment, _reservation);

            // Show deposit amount in textbox
            txtPayableAmt.Text = $"R{deposit:F2}";

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            string cardNumber = txtCardNumber.Text;
            string cvv = txtCVV.Text;

            // Validate card number
            try
            {
                cardNumber = cardNumber.Replace(" ", "");// remove spaces

                // Check that all characters are digits
                if (!cardNumber.All(char.IsDigit))
                    throw new ArgumentException("Card number must contain only digits.");

                // Check length 
                if (cardNumber.Length < 13 || cardNumber.Length > 19)
                    throw new ArgumentException("Card number length is invalid.");

            }
            catch (ArgumentException ex)
            {
                // Stop execution and show the message
                MessageBox.Show(ex.Message, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Validate CVV
            try
            {
                cvv = cvv.Replace(" ", ""); // remove spaces 

                // Check that all characters are digits
                if (!cvv.All(char.IsDigit))
                    throw new ArgumentException("CVV must contain only digits.");

                // Check length: 3 or 4 digits
                if (cvv.Length != 3 && cvv.Length != 4)
                    throw new ArgumentException("CVV must be 3 or 4 digits long.");
            }
            catch (ArgumentException ex)
            {
                // Stop execution and show the message
                MessageBox.Show(ex.Message, "Invalid CVV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Calculate number of days, total amount, deposit, and balance
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;
            decimal totalAmount = _reservation.RoomRate * _reservation.NumberOfRooms * numberOfDays;
            decimal deposit = totalAmount * 0.10m;
            decimal balance = totalAmount - deposit;

            // Create a Payment object
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

            // Save payment to the database
            PaymentDB paymentDB = new PaymentDB();
            paymentDB.AddPaymentAndAccount(payment, _reservation); //calls insert method

            // Optionally display confirmation
            MessageBox.Show("Payment successful");
        }

        private void btnPaymentLater_Click(object sender, EventArgs e) // Event when the user chooses to pay later
        {
            // Calculate number of days, total amount, deposit, and balance
            int numberOfDays = (_reservation.CheckOutDate - _reservation.CheckInDate).Days;
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

            // Save only the account details (no payment processed yet)
            PaymentDB paymentDB = new PaymentDB();
            paymentDB.AddAccount(payment, _reservation);

            // Optionally display confirmation
            MessageBox.Show("Your booking has been saved. You can pay your deposit at a later stage.");

            btnPaymentNow.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlCard.Show();
            btnPaymentNow.Hide();
            


        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this); // pass "this" form
            report.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            About_Page about = new About_Page();
            about.Show();
            this.Hide();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            ManageEdits manageEdits = new ManageEdits();
            manageEdits.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MonthlySalesReport report = new MonthlySalesReport();
            report.Show();
            this.Hide();
        }
    }
}

