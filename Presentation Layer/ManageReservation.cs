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
    }
}
