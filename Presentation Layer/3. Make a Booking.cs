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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class _3 : Form
    {
        public _3()
        {
            InitializeComponent();
        }



        private void _3_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            btnConfirm.Hide();
            lblRoomPrice.Hide();
            txtRoomPrice.Hide();
            lblRP2.Hide();

        }

        #region UI components
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void guna2Button2_Click(object sender, EventArgs e)// "Confirm Reservation"
        {
            int guestID = int.Parse(txtGuestID.Text);
            int numberOfGuests = (int)NumberOfGuests.Value;
            int numberOfRooms = (int)NumberOfRooms.Value;
            DateTime checkInDate = dtpCheckIn.Value.Date;
            DateTime checkOutDate = dtpCheckOut.Value.Date;
            // Minimum rooms required (4 guests per room)
            int requiredRooms = (int)Math.Ceiling(numberOfGuests / 4.0);

            decimal roomRate = RoomController.GetRoomRate(checkInDate);

            // Create a reservation using the controller, passing the selected number of rooms
            ReservationController controller = new ReservationController();
            int reservationID = controller.CreateReservation(guestID, numberOfGuests, checkInDate, checkOutDate, numberOfRooms);


            // Create a Reservation object to pass to PaymentForm
            Reservation reservation = new Reservation(reservationID, guestID, checkInDate, checkOutDate, numberOfRooms, roomRate);


            MessageBox.Show("Reservation Confirmed!");

            PaymentForm paymentForm = new PaymentForm(reservation);
            paymentForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int numberOfGuests = (int)NumberOfGuests.Value;
            int numberOfRooms = (int)NumberOfRooms.Value;
            DateTime checkInDate = dtpCheckIn.Value.Date;
            DateTime checkOutDate = dtpCheckOut.Value.Date;

            // Validate that check-out is after check-in
            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return;
            }

            // Calculate duration of stay
            TimeSpan duration = checkOutDate - checkInDate;
            int numberOfDays = duration.Days;

            // Calculate required rooms
            int requiredRooms = (int)Math.Ceiling((double)numberOfGuests / 4);

            // Ensure the user selected enough rooms
            if (numberOfRooms < requiredRooms)
            {
                MessageBox.Show($"Not enough rooms for {numberOfGuests} guests. Minimum required: {requiredRooms}.");
                return;
            }

            // Get room rate based on check-in date
            decimal roomRate = RoomController.GetRoomRate(checkInDate);

            // Check if rooms are fully booked
            RoomController controller = new RoomController();
            bool fullyBooked = controller.IsFullyBooked(checkInDate, checkOutDate, numberOfRooms);

            if (fullyBooked)
                MessageBox.Show("Sorry, accommodation is not available for the selected dates, Please select new dates");
            else
            {
                MessageBox.Show("Accommadation is available!");

                lblRoomPrice.Show();
                txtRoomPrice.Show();
                lblRP2.Show();
                txtRoomPrice.Text = roomRate.ToString("F2");

                btnConfirm.Show(); //

            }
        }


        private void NumberOfGuests_ValueChanged(object sender, EventArgs e)
        {

            NumberOfGuests.Minimum = 1;
            NumberOfGuests.Maximum = 20;

            // Update required rooms based on guest count
            int NumOfGuests = (int)NumberOfGuests.Value;
            int requiredRooms = (int)Math.Ceiling((double)NumOfGuests / 4);
            NumberOfRooms.Text = requiredRooms.ToString();
        }

        private void NumberOfRooms_ValueChanged(object sender, EventArgs e)
        {
            NumberOfRooms.Minimum = 1;
            NumberOfRooms.Maximum = 5;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
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

        private void guna2Button5_Click(object sender, EventArgs e)
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

        private void btnUser_Click(object sender, EventArgs e)
        {

        }
    }
}
