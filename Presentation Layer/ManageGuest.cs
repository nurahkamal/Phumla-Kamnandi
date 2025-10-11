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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            DataTable guestList = gController.GetAllGuests();
            //Displays on DataGrid
            GuestData.DataSource = guestList;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GuestData.CurrentRow != null)
            {
                DataGridViewRow selectedRow = GuestData.CurrentRow;
                int SelectedGuestID = Convert.ToInt32(GuestData.CurrentRow.Cells["GuestID"].Value);

                string gID = selectedRow.Cells["GuestID"].Value.ToString();
                string FName = selectedRow.Cells["FirstName"].Value.ToString();
                string LName = selectedRow.Cells["LastName"].Value.ToString();

                //MessageBox to confirm Deletion 

                DialogResult msgDelete = MessageBox.Show("Are you sure you want to delte this guest ?\n\n"
                     + "GuestID: " + gID + "\n"
                    + "Name " + FName + " " + LName + "\n",
                    "Confirm Deleted Guest ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                     );

                if (msgDelete == DialogResult.Yes)
                {
                    //Get Guest ID to delte from tables
                    gController.DeleteGuest(gID);

                   

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
            
            txtAddress.Enabled = true;


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Allows guest list to be displayed 
            DataTable guestList = gController.GetAllGuests();
            //Displays on DataGrid
            GuestData.DataSource = guestList;
        }

        private void btnSEdits_Click(object sender, EventArgs e)
        {

            if (GuestData.CurrentRow != null)
            {
                DataGridViewRow selectedRow = GuestData.CurrentRow;
                int SelectedGuestID = Convert.ToInt32(GuestData.CurrentRow.Cells["GuestID"].Value);

                string gID = selectedRow.Cells["GuestID"].Value.ToString();
                string FName = selectedRow.Cells["FirstName"].Value.ToString();
                string LName = selectedRow.Cells["LastName"].Value.ToString();
                string gid = GuestData.CurrentRow.Cells["GuestID"].Value.ToString();

                string name = txtName.Text;
                string lastname = txtSurname.Text;
                string ID = txtID.Text;
                string address = txtAddress.Text;
                string PhoneNo = txtPhone.Text;
                string email = txtEmail.Text;


                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(ID)
    || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(PhoneNo) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Enter information in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // lastname and name must only contain letters
                if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(lastname, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Name and surname can only contain letters and spaces", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ID must be 13 digits
                if (!long.TryParse(ID, out _) || ID.Length != 13)
                {
                    MessageBox.Show("ID must be 13 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Phone number must be 10 digits
                if (!long.TryParse(PhoneNo, out _) || PhoneNo.Length != 10)
                {
                    MessageBox.Show("Phone number must be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Email must contain @
                if (!email.Contains("@"))
                {
                    MessageBox.Show("Invalid email, email should contain '@'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DialogResult msgUpdate = MessageBox.Show("Are you sure you want to edit this guest ?\n\n"
                    + "GuestID: " + gID + "\n"
                   + "Name " + FName + " " + LName + "\n",
                   "Confirm Edited Guest ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                    );

                if (msgUpdate == DialogResult.Yes)
                {
                    //Get Guest ID to delte from tables
                    gController.UpdateGuest(txtGid.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtEmail.Text, txtID.Text, txtAddress.Text, Convert.ToInt32(strLpoints.Value));



                }

                 
                
            
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            //Makes sure field isnt blank
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a Guest ID.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int searchID;
            try
            {

                searchID = Convert.ToInt32(txtSearch.Text);
            }
            catch
            {
                MessageBox.Show("Guest ID must be a number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Clear();
                return;
            }

            bool found = false;

            //  Search the DataGridView
            foreach (DataGridViewRow gRow in GuestData.Rows)
            {
                if (gRow.Cells["GuestID"].Value != null &&
                    Convert.ToInt32(gRow.Cells["GuestID"].Value) == searchID)
                {
                    GuestData.ClearSelection();
                    gRow.Selected = true;
                    GuestData.FirstDisplayedScrollingRowIndex = gRow.Index;
                    found = true;
                    break;
                }
            }

            // If RID doesnt match  DataGrid
            if (!found)
            {
                GuestData.ClearSelection();
                MessageBox.Show($"No Guest found with ID {searchID}.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();
            login.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ManageEdits manageEdits = new ManageEdits();
            manageEdits.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

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
    }
}
