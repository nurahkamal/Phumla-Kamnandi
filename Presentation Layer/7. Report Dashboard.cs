using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class Report_Dashboard : Form
    {
        private ReportController model;

        public Report_Dashboard()
        {
            InitializeComponent();
            // Initialize model
            model = new ReportController();

            // Default date range: last 7 days
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;
            LoadData();
        }

        #region Load Data
        private void LoadData()
        {
            bool refreshed = model.LoadReport(dtpStartDate.Value, dtpEndDate.Value);

            if (refreshed)
            {
                // Update Labels
                lblTotalRevenue.Text = "R" + model.TotalRevenue.ToString("N2");
               
                lblNumberOfReservations.Text = model.NumberOfReservations.ToString();
              
                

                #region Doughnut Chart - Revenue by Season
                decimal lowSeason = model.RevenueSummary
                    .Where(r => DateTime.ParseExact(r.Date, "dd MMM", null).Day >= 1 && DateTime.ParseExact(r.Date, "dd MMM", null).Day <= 7)
                    .Sum(r => r.TotalAmount);

                decimal midSeason = model.RevenueSummary
                    .Where(r => DateTime.ParseExact(r.Date, "dd MMM", null).Day >= 8 && DateTime.ParseExact(r.Date, "dd MMM", null).Day <= 15)
                    .Sum(r => r.TotalAmount);

                decimal highSeason = model.RevenueSummary
                    .Where(r => DateTime.ParseExact(r.Date, "dd MMM", null).Day >= 16)
                    .Sum(r => r.TotalAmount);

                chartRevenueBySeason.Series[0].Points.Clear();
                chartRevenueBySeason.Series[0].Points.AddXY("Low", lowSeason);
                chartRevenueBySeason.Series[0].Points.AddXY("Mid", midSeason);
                chartRevenueBySeason.Series[0].Points.AddXY("High", highSeason);
                chartRevenueBySeason.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                chartRevenueBySeason.DataBind();
                #endregion

                #region Bar Chart - Revenue by Date
                chartRevenueByDate.DataSource = model.RevenueSummary;
                chartRevenueByDate.Series[0].XValueMember = "Date";
                chartRevenueByDate.Series[0].YValueMembers = "TotalAmount";
                chartRevenueByDate.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chartRevenueByDate.DataBind();
                #endregion

                #region Line Chart - Cumulative Revenue
                decimal cumulative = 0;
                var cumulativeData = model.RevenueSummary
                    .Select(r =>
                    {
                        cumulative += r.TotalAmount;
                        return new RevenueByDate { Date = r.Date, TotalAmount = cumulative };
                    }).ToList();

                chartCumulativeRevenue.DataSource = cumulativeData;
                chartCumulativeRevenue.Series[0].XValueMember = "Date";
                chartCumulativeRevenue.Series[0].YValueMembers = "TotalAmount";
                chartCumulativeRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chartCumulativeRevenue.DataBind();
                #endregion

                MessageBox.Show("Dashboard loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data not refreshed; same query.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Date Buttons
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            LoadData();
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;
            LoadData();
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Today;
            LoadData();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Today;
            LoadData();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkay.Visible = true;
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

