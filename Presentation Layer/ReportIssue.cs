using System;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class ReportIssue : Form
    {
        private Form _previousForm;

        // Constructor that takes the previous form as a parameter
        public ReportIssue(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            _previousForm.Show();
        }
    }
}
