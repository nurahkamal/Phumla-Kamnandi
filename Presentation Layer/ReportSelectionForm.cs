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
    public partial class ReportSelectionForm : Form
    {
        public ReportSelectionForm()
        {
            InitializeComponent();
            InitializeBehavior();
        }

        private void InitializeBehavior()
        {
            // Initially hide report buttons until checkbox is checked
            btnSales.Visible = false;
            btnOccupancy.Visible = false;
            label16.Visible = false;

            // Hook up checkbox event
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            // Hook up button clicks
            btnSales.Click += BtnSales_Click;
            btnOccupancy.Click += BtnOccupancy_Click;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Show/hide report buttons based on checkbox
            bool accepted = checkBox1.Checked;
            btnSales.Visible = accepted;
            btnOccupancy.Visible = accepted;
            label16.Visible = accepted;
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please accept the terms before viewing reports!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open your MonthlySalesReport form
            MonthlySalesReport salesForm = new MonthlySalesReport();
            salesForm.Show();
        }

        private void BtnOccupancy_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please accept the terms before viewing reports!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open your OccupancyReport form
            OccupancyReport occForm = new OccupancyReport();
            occForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}