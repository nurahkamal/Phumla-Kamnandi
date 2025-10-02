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

        }

        private void GuestData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
