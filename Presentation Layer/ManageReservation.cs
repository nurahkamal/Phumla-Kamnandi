using Guna.UI2.AnimatorNS;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Data;
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
            }
        }

        private void btnSEdits_Click(object sender, EventArgs e)
        {
            if (ReservationData.CurrentRow != null)
            {
                string gid = ReservationData.CurrentRow.Cells["ReservationID"].Value.ToString();
                // rController.UpdateReservation(...) // implement update logic here
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

        private void ReservationData_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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
    }
}
