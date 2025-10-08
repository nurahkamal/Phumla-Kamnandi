using Guna.UI2.AnimatorNS;
using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class ManageReservation : Form
    {
        private ReservationController rController;

        public ManageReservation()
        {
            InitializeComponent();
            rController = new ReservationController();
        }

        private void ManageReservation_Load(object sender, EventArgs e)
        {
            // Allows guest list to be displayed
            DataTable RList = rController.GetAllReservations();
            // Displays on DataGrid
            ReservationData.DataSource = RList;
        }

        private void ReservationData_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSEdits_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationID = int.Parse(txtRID.Text);       // Reservation to update
                int newGuests = (int)NumberOfGuests.Value;       // New number of guests
                int newRooms = (int)NumberOfRooms.Value;         // New number of rooms
                DateTime newCheckIn = dtpCheckIn.Value.Date;     // New check-in date
                DateTime newCheckOut = dtpCheckOut.Value.Date;   // New check-out date

                // Validate dates
                if (newCheckOut <= newCheckIn)
                {
                    MessageBox.Show("Check-out date must be after check-in date.");
                    return;
                }

                // Ensure enough rooms for guests (4 guests per room)
                int requiredRooms = (int)Math.Ceiling(newGuests / 4.0);
                if (newRooms < requiredRooms)
                {
                    MessageBox.Show($"Not enough rooms. Minimum required: {requiredRooms}.");
                    return;
                }

                // Get available rooms directly from RoomDB
                RoomDB roomDB = new RoomDB();
                List<int> roomIDs = roomDB.GetAvailableRooms(newCheckIn, newCheckOut, newRooms);

                if (roomIDs.Count < newRooms)
                {
                    MessageBox.Show("Not enough rooms available for the selected dates.");
                    return;
                }

                // Get room rate
                decimal roomRate = RoomController.GetRoomRate(newCheckIn);

                // Update the reservation
                bool success = rController.UpdateReservation(reservationID, newGuests, newCheckIn, newCheckOut, roomIDs, roomRate);

                if (success)
                    MessageBox.Show("Reservation updated successfully!");
                else
                    MessageBox.Show("Failed to update reservation.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchRID = txtSearchRid.Text;

            foreach (DataGridViewRow gRow in ReservationData.Rows)
            {
                if (gRow.Cells["ReservationID"].Value != null && gRow.Cells["ReservationID"].Value.ToString() == searchRID)
                {
                    ReservationData.FirstDisplayedScrollingRowIndex = gRow.Index;
                    gRow.Selected = true;
                    break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ReservationData.CurrentRow != null)
            {
                DataGridViewRow selectedRow = ReservationData.CurrentRow;

                string rID = selectedRow.Cells["ReservationID"].Value.ToString();
                string gid = selectedRow.Cells["GuestID"].Value.ToString();

                DialogResult msgDelete = MessageBox.Show(
                    "Are you sure you want to delete this guest?\n\n" +
                    "ReservationID: " + rID + "\n" +
                    "GuestID: " + gid + "\n",
                    "Confirm Delete Guest",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (msgDelete == DialogResult.Yes)
                {
                    rController.DeleteReservation(rID);
                    MessageBox.Show("Guest Deleted Successfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom paint logic
        }

        private void ReservationData_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
            


        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void lblGuestID_Click(object sender, EventArgs e) { }
        private void lblPassNum_Click(object sender, EventArgs e) { }
        private void lblID_Click(object sender, EventArgs e) { }
        private void lblPhone_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this);
            report.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable RList = rController.GetAllReservations();
        }

        private void ReservationData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Displays Clicked Data onto textboxes
            if (ReservationData.CurrentRow != null)
            {
                DataGridViewRow SelectedR = ReservationData.CurrentRow;

                txtRID.Text = SelectedR.Cells["ReservationID"].Value.ToString();
                txtGid.Text = SelectedR.Cells["GuestID"].Value.ToString();
                dtpRDate.Value = Convert.ToDateTime(SelectedR.Cells["ReservationDate"].Value);
                dtpCheckIn.Value = Convert.ToDateTime(SelectedR.Cells["CheckInDate"].Value);
                dtpCheckOut.Value = Convert.ToDateTime(SelectedR.Cells["CheckOutDate"].Value);
                NumberOfGuests.Value = Convert.ToDecimal(SelectedR.Cells["NumberOfGuests"].Value);

                string Bstatus = SelectedR.Cells["BookingStatus"].Value.ToString();
                cmboBStatus.SelectedItem = cmboBStatus.Items.Contains(Bstatus) ? Bstatus : null;

                string Pstatus = SelectedR.Cells["PaymentStatus"].Value.ToString();
                cmboPStatus.SelectedItem = cmboPStatus.Items.Contains(Pstatus) ? Pstatus : null;

                int reservationID = Convert.ToInt32(SelectedR.Cells["ReservationID"].Value); // declare reservationID
                decimal totalPayment = 0; // declare totalPayment

                //Shows Total Amount from Account Tables
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True"))
                {
                    conn.Open();
                    string sql = @"SELECT TotalAmount FROM Accounts WHERE ReservationID = @ResID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResID", reservationID);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            totalPayment = Convert.ToDecimal(result);
                    }
                }

                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
