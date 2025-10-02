using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class ManageGuest : Form
        
        
    {
        private GuestController gController;
        public ManageGuest()
        {
            InitializeComponent();
        gController = new GuestController(); 

        }

        private void ManageGuest_Load(object sender, EventArgs e)


        {  //Allows guest list to be displayed 
            DataTable guestList = gController.SeeAllGuests();
            //Displays on DataGrid
            GuestData.DataSource = guestList;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GuestData.CurrentRow != null)
                {
                DataGridViewRow SelectedGuest = GuestData.CurrentRow;

                string gID = SelectedGuest.Cells["GuestID"].Value.ToString(); 
                string FName = SelectedGuest.Cells["FirstName"].Value.ToString();
                string LName =SelectedGuest.Cells["LastName"].Value.ToString();
                
                //MessageBox to confirm Deletion 

                DialogResult msgDelete = MessageBox.Show("Are you sure you want to delte this guest ?\n\n"
                    + "GuestID: " + gID + "\n"
                    + "Name " + FName + " " + LName + "\n",
                    "Confirm Deleted Guest ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                    ); 

                if ( msgDelete == DialogResult.Yes)
                {
                    //Get Guest ID to delte from tables
                    gController.DeleteGuest(gID);

                    MessageBox.Show("Guest Deleted Successfully ", "Deleted Success",MessageBoxButtons.OK ,  MessageBoxIcon.Information); 

                }



             


            }
        }

        private void GuestData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GuestData_SelectionChanged(object sender, EventArgs e)
        {
            
            //If at least One cell is selcted populate the tables
            if (GuestData.CurrentRow !=null)
            {
                DataGridViewRow SelectedGuest = GuestData.CurrentRow;

                txtGid.Text = SelectedGuest.Cells["GuestID"].Value.ToString();
                txtName.Text = SelectedGuest.Cells["FirstName"].Value.ToString();
                txtSurname.Text = SelectedGuest.Cells["LastName"].Value.ToString();
                txtPhone.Text = SelectedGuest.Cells["Phone"].Value.ToString();
                txtEmail.Text = SelectedGuest.Cells["Email"].Value.ToString();
                txtID.Text = SelectedGuest.Cells["IDNumber"].Value.ToString();
                txtPassNum.Text = SelectedGuest.Cells["PassportNo"].Value.ToString();
                txtAddress.Text = SelectedGuest.Cells["Address"].Value.ToString();
                
                strLpoints.Value = Convert.ToInt32(SelectedGuest.Cells["LoyaltyPoints"].Value);






            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           //Allows User to edit textboxes

            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtID.Enabled = true;
            txtPassNum.Enabled = true;
            txtAddress.Enabled = true;


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Allows guest list to be displayed 
            DataTable guestList = gController.SeeAllGuests();
            //Displays on DataGrid
            GuestData.DataSource = guestList;
        }

        private void btnSEdits_Click(object sender, EventArgs e)
        {

            if (GuestData.CurrentRow != null)
            {
                string gid = GuestData.CurrentRow.Cells["GuestID"].Value.ToString();
                gController.UpdateGuest(txtGid.Text,txtName.Text ,txtSurname.Text,txtPhone.Text,txtEmail.Text,txtID.Text,txtPassNum.Text,txtAddress.Text); 
                
            
            }
        }
    }
}
