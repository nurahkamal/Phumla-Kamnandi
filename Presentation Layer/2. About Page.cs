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
    public partial class About_Page : Form
    {
        public About_Page()
        {
            InitializeComponent();
        }
        int Count = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Count < 11)
            {
                pictureBox1.Image = imageList1.Images[Count];
                Count++;
            }
            else
                Count = 0;
        }
    }
}
