using System;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class ReportIssue : Form
    {
        private Form previousForm;

        public ReportIssue(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        // Handle the Exit button click (top right corner)
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Confirm before exiting
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit this page?",
                "Exit Report Issue",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Go back to previous form
                previousForm.Show();
                this.Close();
            }
        }

        // Handle the Back button click (bottom)
        private void btnBack_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }

        // Handle the Submit button click
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString();
            string description = txtDescription.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please describe the issue before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pretend to send report (you can later connect this to a DB or email handler)
            MessageBox.Show(
                "Thank you for taking the time to report this issue.\n\n" +
                "Our support team will review your report and get back to you if necessary.\n\n" +
                "We apologize for the inconvenience and appreciate your patience!",
                "Issue Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Clear fields after submission
            cmbCategory.SelectedIndex = -1;
            txtDescription.Clear();
            txtEmail.Clear();
        }
    }
}
