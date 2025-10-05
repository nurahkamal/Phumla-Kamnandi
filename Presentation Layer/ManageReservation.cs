using Guna.UI2.AnimatorNS;
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
using System.Xml.Linq;

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
            //Allows guest list to be displayed 
            DataTable RList = rController.GetAllReservations();
            //Displays on DataGrid
            ReservationData.DataSource = RList;

        }

        private void ReservationData_SelectionChanged(object sender, EventArgs e)
        {
            //If at least One cell is selcted populate the tables
            if (ReservationData.CurrentRow != null)
            {
                DataGridViewRow SelectedR = ReservationData.CurrentRow;

                txtRID.Text = SelectedR.Cells["ReservationID"].Value.ToString();
                txtGid.Text = SelectedR.Cells["GuestID"].Value.ToString();
                dtpRDate.Value = Convert.ToDateTime(SelectedR.Cells["ReservationDate"].Value);
                dtpCheckIn.Value = Convert.ToDateTime(SelectedR.Cells["CheckInDate"].Value);
                dtpCheckOut.Value = Convert.ToDateTime(SelectedR.Cells["CheckOutDate"].Value);
                NumberOfGuests.Value = Convert.ToDecimal(SelectedR.Cells["NumberOfGuests"].Value);
                // Mustn this be added in the table
                // NumberOfRooms.Value = Convert.ToDecimal(SelectedR.Cells["NumberOfRooms"].Value);

                string Bstatus = SelectedR.Cells["BookingStatus"].Value.ToString();
                if (cmboBStatus.Items.Contains(Bstatus))
                    cmboBStatus.SelectedItem = Bstatus;
                else
                    cmboBStatus.SelectedIndex = -1;

                string Pstatus = SelectedR.Cells["PaymentStatus"].Value.ToString();
                if (cmboPStatus.Items.Contains(Pstatus))
                    cmboPStatus.SelectedItem = Pstatus;
                else
                    cmboBStatus.SelectedIndex = -1;


            }





            
        }

        private void btnSEdits_Click(object sender, EventArgs e)
        {
            if (ReservationData.CurrentRow != null)
            {
                string gid = ReservationData.CurrentRow.Cells["ReservationID"].Value.ToString();
               // rController.UpdateReservation(txttxtGid.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtEmail.Text, txtID.Text, txtPassNum.Text, txtAddress.Text);


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchRID = txtSearchRid.Text;

            foreach (DataGridViewRow gRow in ReservationData.Rows)
            {


                if (gRow.Cells["ReservationID"].Value != null && gRow.Cells["ReservationID"].Value.ToString() == searchRID)
                {
                    // Scroll the DataGridView so this row is visible
                    ReservationData.FirstDisplayedScrollingRowIndex = gRow.Index;




                }


            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservationData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGuestID_Click(object sender, EventArgs e)
        {

        }

        private void lblPassNum_Click(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            ReportIssue report = new ReportIssue(this); // pass "this" form
            report.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
            this.Hide();
        }
    }
}
