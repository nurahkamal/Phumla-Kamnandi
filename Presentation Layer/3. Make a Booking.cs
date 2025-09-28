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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int guestID = int.Parse(txtGuestID.Text);
            int numberOfGuests = (int)NumberOfGuests.Value;
            DateTime checkInDate = dtpCheckIn.Value.Date;
            DateTime checkOutDate = dtpCheckOut.Value.Date;
            int numberOfRooms = (int)Math.Ceiling(numberOfGuests / 4.0);
            decimal roomRate = ReservationController.GetRoomRate(checkInDate);

            
            ReservationController controller = new ReservationController();
            int reservationID = controller.CreateReservation(guestID, numberOfGuests, checkInDate, checkOutDate);
            Reservation reservation = new Reservation(reservationID,guestID,checkInDate,checkOutDate,numberOfRooms,roomRate);

            MessageBox.Show("Reservation successfully added to the database!");

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
            DateTime checkInDate = dtpCheckIn.Value.Date;
            DateTime checkOutDate = dtpCheckOut.Value.Date;


            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.");
                return;
            }

            TimeSpan duration = checkOutDate - checkInDate;
            int numberOfDays = duration.Days;


            int numberOfRooms = (int)Math.Ceiling(numberOfGuests / 4.0);
            txtNumberOfRooms.Text = numberOfRooms.ToString();


            decimal roomRate = ReservationController.GetRoomRate(checkInDate);


            ReservationController controller = new ReservationController();
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

                btnConfirm.Show();

            }
        }

           
        

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumberOfGuests_ValueChanged(object sender, EventArgs e)
        {

            NumberOfGuests.Minimum = 1;
            NumberOfGuests.Maximum = 12;

            int NumOfGuests = (int)NumberOfGuests.Value;
            int requiredRooms = (int)Math.Ceiling((double)NumOfGuests / 4);
            txtNumberOfRooms.Text = requiredRooms.ToString();
        }
    }
}
