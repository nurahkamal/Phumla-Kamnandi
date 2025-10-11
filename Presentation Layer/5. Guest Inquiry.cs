using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class _5 : Form
    {
        private ReservationController rController;
        public _5()
        {

            InitializeComponent();

            rController = new ReservationController();
        }

        private void ReservationData_CellClick(object sender, DataGridViewCellEventArgs e)
        { //Displays Clicked Data onto textboxes
            if (ReservationData.CurrentRow != null)
            {
                DataGridViewRow SelectedR = ReservationData.CurrentRow;

                lblIRID.Text = SelectedR.Cells["ReservationID"].Value.ToString();
                label5.Text = SelectedR.Cells["GuestID"].Value.ToString();
                lblP.Text = SelectedR.Cells["PaymentStatus"].Value.ToString();
                dtpRDate.Value = Convert.ToDateTime(SelectedR.Cells["ReservationDate"].Value);
                dtpCheckIn.Value = Convert.ToDateTime(SelectedR.Cells["CheckInDate"].Value);
                dtpCheckOut.Value = Convert.ToDateTime(SelectedR.Cells["CheckOutDate"].Value);
                NumberOfGuests.Value = Convert.ToDecimal(SelectedR.Cells["NumberOfGuests"].Value);



                int reservationID = Convert.ToInt32(SelectedR.Cells["ReservationID"].Value);
                NumberOfRooms.Value = rController.GetRoomCount(reservationID);

                 

            }




        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _5_Load(object sender, EventArgs e)
        {
            // Allows guest list to be displayed
            DataTable RList = rController.GetAllReservations();
            // Displays on DataGrid
            ReservationData.DataSource = RList;

            lblIRID.Text = "";
            label5.Text = "";
            
            lblP.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Makes sure field isnt blank
            if (string.IsNullOrWhiteSpace(txtSearchRid.Text))
            {
                MessageBox.Show("Please enter a Reservation ID.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int searchRID;
            try
            {

                searchRID = Convert.ToInt32(txtSearchRid.Text);
            }
            catch
            {
                MessageBox.Show("Reservation ID must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchRid.Clear();
                return;
            }

            bool found = false;

            //  Search the DataGridView
            foreach (DataGridViewRow gRow in ReservationData.Rows)
            {
                if (gRow.Cells["ReservationID"].Value != null &&
                    Convert.ToInt32(gRow.Cells["ReservationID"].Value) == searchRID)
                {
                    ReservationData.ClearSelection();
                    gRow.Selected = true;
                    ReservationData.FirstDisplayedScrollingRowIndex = gRow.Index;
                    found = true;
                    break;
                }
            }

            // If RID doesnt match  DataGrid
            if (!found)
            {
                ReservationData.ClearSelection();
                MessageBox.Show($"No reservation found with ID {searchRID}.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable RList = rController.GetAllReservations();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this);
            report.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home_Pagecs home_Page = new Home_Pagecs();
            home_Page.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmCreateGuest creatGuest = new frmCreateGuest();
            creatGuest.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ManageEdits manageEdits = new ManageEdits();
            manageEdits.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            _5 guest_enquiries = new _5();
            guest_enquiries.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ReportLoginFormcs reportLoginForm = new ReportLoginFormcs();
            reportLoginForm.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            About_Page about = new About_Page();
            about.Show();
            this.Hide();
        }
    }


}
