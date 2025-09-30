using Phumla_Kamnandi.Business_Layer;
using Phumla_Kamnandi.Data_Layer;
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
    public partial class _6 : Form

    {
        private GuestController guestController; 
        public _6()
        {
            InitializeComponent();
            guestController = new GuestController();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void _6_Load(object sender, EventArgs e)
        {
            //Display the data from the Guest Table 

            DataTable guests = guestController.SeeAllGuests();
            GuestView.DataSource = guests; 
        }

        private void GuestView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GuestView_SelectionChanged(object sender, EventArgs e)
        {  

            
          // If a user chooses a selected row 
            if ( GuestView.SelectedRows.Count > 0)

            { //declare Selected Guest
                DataGridViewRow SelectedGuest = GuestView.SelectedRows[0];

                //Display in TextBoxes
                int GuestID= Convert.ToInt32(SelectedGuest.Cells["GuestID"].Value);


                txtGid.Text = GuestID.ToString();

                //txtPid.Text = SelectedGuest.Cells["IDNumber"].Value.ToString();

                txtGName.Text = SelectedGuest.Cells["FirstName"].Value.ToString();

                txtGSurname.Text = SelectedGuest.Cells["LastName"].Value.ToString();

               // txtPassNum.Text = SelectedGuest.Cells["PassportNo"].Value.ToString(); 

                txtPhone.Text = SelectedGuest.Cells["Phone"].Value.ToString();


                txtEmail.Text = SelectedGuest.Cells["Email"].Value.ToString();

                txtAddress.Text = SelectedGuest.Cells["Address"].Value.ToString();

                //Display Loyalty Points on Stars
                int LPoints = Convert.ToInt32(SelectedGuest.Cells["LoyaltyPoints"].Value);
                strlPoints.Value = LPoints;





            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (GuestView.SelectedRows.Count > 0)
            {
                string SelectedGuest = GuestView.SelectedRows[0].Cells[0].Value.ToString();
                guestController.DeleteGuest(SelectedGuest);

               
            }

            else
            {
                MessageBox.Show("No Guest ID found in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
