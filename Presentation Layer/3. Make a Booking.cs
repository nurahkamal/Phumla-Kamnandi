using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_Kamnandi.Presentation_Layer;

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
            PaymentForm form8 = new PaymentForm();   // create an instance of Form _8
            form8.Show();          // show Form _8
            this.Hide();           // hide the current Form _3 (optional)
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
