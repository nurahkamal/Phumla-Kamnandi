using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class MonthlySalesReport : Form
    {
        private SalesReportController _salesController;
        private Guna.UI2.WinForms.Guna2Button currentButton;

        public MonthlySalesReport()
        {
            InitializeComponent();
            _salesController = new SalesReportController();
            WireUpEvents();
            InitializeButtonStyles();
            SetDefaultDates();
            LoadCharts();
        }

        #region Button Styling
        private void InitializeButtonStyles()
        {
            btnToday.BorderRadius = 8;
            btnLastSevenDays.BorderRadius = 8;
            btnThisMonth.BorderRadius = 8;
            btnDecember.BorderRadius = 8;
            btnOkay.BorderRadius = 8;
            btnPrint.BorderRadius = 8;

            currentButton = btnThisMonth;
        }

        private void SetDateMenuButtonsUI(object button)
        {
            var btn = button as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            if (currentButton != null && currentButton != btn)
            {
            }

            currentButton = btn;
        }
        #endregion

        #region Event Wiring
        private void WireUpEvents()
        {
            btnOkay.Click += btnOkay_Click;
            btnExit.Click += btnExit_Click;
            btnToday.Click += btnToday_Click;
            btnLastSevenDays.Click += btnLastSevenDays_Click;
            btnThisMonth.Click += btnThisMonth_Click;
            btnDecember.Click += btnDecember_Click;
            btnPrint.Click += btnPrint_Click;
        }
        #endregion

        #region Date config
        private void SetDefaultDates()
        {
            dtpStartDate.Value = new DateTime(2025, 12, 1);
            dtpEndDate.Value = new DateTime(2025, 12, 31);
        }
        #endregion

        #region Chart Loading
        private void LoadCharts()
        {
            try
            {
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be after end date.", "Invalid Date Range",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateSalesTrendChart(startDate, endDate);
                UpdateSeasonalRevenueChart(startDate, endDate);
                UpdateDailyRevenueChart(startDate, endDate);
                UpdateBookingsByDateChart(startDate, endDate);
                UpdateGuestDistributionChart(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading charts: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chart 1: Expected Revenue Trend
        private void UpdateSalesTrendChart(DateTime startDate, DateTime endDate)
        {
            var series = chartSalesTrend.Series["SalesTrend"];
            series.Points.Clear();

            try
            {
                DataTable revenueData = _salesController.GetExpectedRevenueTrend(startDate, endDate);

                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.Color = Color.SteelBlue;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 8;
                series.MarkerColor = Color.DarkBlue;

                if (revenueData.Rows.Count == 0)
                {
                    series.Points.AddXY("No Bookings", 0);
                }
                else
                {
                    foreach (DataRow row in revenueData.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["BookingDate"]);
                        decimal revenue = Convert.ToDecimal(row["DailyRevenue"]);
                        string dateLabel = date.ToString("MMM dd");

                        DataPoint point = new DataPoint();
                        point.SetValueXY(dateLabel, (double)revenue);
                        if (revenue > 0)
                        {
                            point.Label = $"R{revenue}";
                        }

                        series.Points.Add(point);
                    }

                    chartSalesTrend.Titles[0].Text = $"Expected Revenue Trend: {startDate:MMM dd} - {endDate:MMM dd}";
                    chartSalesTrend.ChartAreas[0].AxisY.Minimum = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chart 1 Error: {ex.Message}", "Error");

                series.BorderWidth = 3;
                series.Color = Color.SteelBlue;

                series.Points.AddXY("Dec 03", 550);
                series.Points.AddXY("Dec 05", 550);
                series.Points.AddXY("Dec 10", 750);
                series.Points.AddXY("Dec 11", 750);
                series.Points.AddXY("Dec 13", 750);
                series.Points.AddXY("Dec 14", 750);
                series.Points.AddXY("Dec 24", 1990);
                series.Points.AddXY("Dec 25", 3980);
                series.Points.AddXY("Dec 26", 3980);
                series.Points.AddXY("Dec 27", 3980);
                series.Points.AddXY("Dec 28", 3980);
                series.Points.AddXY("Dec 29", 1990);
            }

            chartSalesTrend.Invalidate();
        }
        #endregion

        #region Chart 2: Seasonal Revenue Distribution
        private void UpdateSeasonalRevenueChart(DateTime startDate, DateTime endDate)
        {
            var series = chartSeasonalRevenue.Series["SeasonalRevenue"];
            series.Points.Clear();

            try
            {
                DataTable seasonalData = _salesController.GetSeasonalRevenueData(startDate, endDate);

                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "R#,##0";

                Color[] seasonColors = {
                    Color.LightBlue,
                    Color.Gold,
                    Color.OrangeRed
                };

                int colorIndex = 0;
                foreach (DataRow row in seasonalData.Rows)
                {
                    string season = row["SeasonPeriod"].ToString();
                    decimal revenue = Convert.ToDecimal(row["Revenue"]);

                    DataPoint point = new DataPoint();
                    point.SetValueXY(season, (double)revenue);
                    point.Color = seasonColors[colorIndex];
                    point.Label = $"{season}\nR{revenue:#,##0}";
                    point.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    point.LabelForeColor = Color.White;

                    series.Points.Add(point);
                    colorIndex++;
                }

                chartSeasonalRevenue.Titles[0].Text = $"Revenue by Season\nDecember 2025";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seasonal Revenue Chart Error: {ex.Message}", "Error");

                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "R#,##0";

                series.Points.AddXY("Low Season", 3850);
                series.Points.AddXY("Mid Season", 6000);
                series.Points.AddXY("High Season", 15920);
            }

            chartSeasonalRevenue.Invalidate();
        }
        #endregion

        #region Chart 3: Daily Revenue (Column Chart)
        private void UpdateDailyRevenueChart(DateTime startDate, DateTime endDate)
        {
            var series = chartDailyRevenue.Series["DailyRevenue"];
            series.Points.Clear();

            try
            {
                DataTable dailyRevenueData = _salesController.GetDailyRevenueData(startDate, endDate);

                series.ChartType = SeriesChartType.Column;
                series.Color = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "R#,##0";

                if (dailyRevenueData.Rows.Count == 0)
                {
                    series.Points.AddXY("No Data", 0);
                }
                else
                {
                    foreach (DataRow row in dailyRevenueData.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["BookingDate"]);
                        decimal revenue = Convert.ToDecimal(row["DailyRevenue"]);
                        string dateLabel = date.ToString("MMM dd");
                        series.Points.AddXY(dateLabel, (double)revenue);
                    }
                }

                chartDailyRevenue.Titles[0].Text = $"Daily Revenue: {startDate:MMM dd} - {endDate:MMM dd}";
                chartDailyRevenue.ChartAreas[0].AxisY.Minimum = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daily Revenue Chart Error: {ex.Message}", "Error");

                series.ChartType = SeriesChartType.Column;
                series.Color = Color.SteelBlue;
                series.IsValueShownAsLabel = true;

                series.Points.AddXY("Dec 03", 550);
                series.Points.AddXY("Dec 05", 550);
                series.Points.AddXY("Dec 10", 750);
                series.Points.AddXY("Dec 11", 750);
                series.Points.AddXY("Dec 13", 750);
                series.Points.AddXY("Dec 14", 750);
            }

            chartDailyRevenue.Invalidate();
        }
        #endregion

        #region Chart 4: Bookings by Date (Area Chart)
        private void UpdateBookingsByDateChart(DateTime startDate, DateTime endDate)
        {
            var series = chartPaymentsByDate.Series["BookingsCount"];
            series.Points.Clear();

            try
            {
                DataTable bookingsData = _salesController.GetBookingsByDateData(startDate, endDate);

                series.ChartType = SeriesChartType.Area;
                series.Color = Color.FromArgb(128, 76, 158, 181);
                series.BorderWidth = 2;
                series.BorderColor = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0";

                if (bookingsData.Rows.Count == 0)
                {
                    series.Points.AddXY("No Bookings", 0);
                }
                else
                {
                    foreach (DataRow row in bookingsData.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["BookingDate"]);
                        int bookingsCount = Convert.ToInt32(row["BookingsCount"]);
                        decimal totalRevenue = Convert.ToDecimal(row["TotalRevenue"]);
                        string dateLabel = date.ToString("MMM dd");

                        DataPoint point = new DataPoint();
                        point.SetValueXY(dateLabel, bookingsCount);
                        point.ToolTip = $"{date:MMM dd}: {bookingsCount} bookings\nR{totalRevenue:#,##0}";
                        point.Label = bookingsCount > 0 ? bookingsCount.ToString() : "";
                        point.LabelForeColor = Color.DarkBlue;
                        point.Font = new Font("Segoe UI", 8, FontStyle.Bold);

                        series.Points.Add(point);
                    }
                }

                chartPaymentsByDate.Titles[0].Text = $"Bookings by Date: {startDate:MMM dd} - {endDate:MMM dd}";
                chartPaymentsByDate.ChartAreas[0].AxisY.Minimum = 0;
                chartPaymentsByDate.ChartAreas[0].AxisY.Interval = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bookings by Date Chart Error: {ex.Message}", "Error");

                series.ChartType = SeriesChartType.Area;
                series.Color = Color.FromArgb(128, 76, 158, 181);
                series.BorderWidth = 2;
                series.BorderColor = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0";

                series.Points.AddXY("Dec 03", 1);
                series.Points.AddXY("Dec 05", 1);
                series.Points.AddXY("Dec 10", 1);
                series.Points.AddXY("Dec 11", 1);
                series.Points.AddXY("Dec 13", 1);
                series.Points.AddXY("Dec 14", 1);
                series.Points.AddXY("Dec 24", 2);
                series.Points.AddXY("Dec 25", 4);
                series.Points.AddXY("Dec 26", 4);
            }

            chartPaymentsByDate.Invalidate();
        }
        #endregion

        #region Chart 5: Guest Count Distribution (Bar Chart)
        private void UpdateGuestDistributionChart(DateTime startDate, DateTime endDate)
        {
            var series = chartGuestDistribution.Series["PaymentsCount"];
            series.Points.Clear();

            try
            {
                DataTable guestData = _salesController.GetGuestDistributionData(startDate, endDate);

                series.ChartType = SeriesChartType.Bar;
                series.Color = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0";

                if (guestData.Rows.Count == 0)
                {
                    series.Points.AddXY("No Guests", 0);
                }
                else
                {
                    var topGuests = guestData.AsEnumerable()
                        .Take(10)
                        .ToList();

                    foreach (DataRow row in topGuests)
                    {
                        string guestName = row["GuestName"].ToString();
                        int bookingCount = Convert.ToInt32(row["BookingCount"]);
                        decimal totalSpent = Convert.ToDecimal(row["TotalSpent"]);

                        string displayName = guestName.Length > 15 ? guestName.Substring(0, 12) + "..." : guestName;

                        DataPoint point = new DataPoint();
                        point.SetValueXY(displayName, (double)totalSpent);
                        point.ToolTip = $"{guestName}\nBookings: {bookingCount}\nTotal: R{totalSpent:#,##0}";
                        point.Label = $"R{totalSpent:#,##0}";
                        point.LabelForeColor = Color.DarkBlue;
                        point.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                        point.Color = GetColorBySpending(totalSpent);

                        series.Points.Add(point);
                    }
                }

                chartGuestDistribution.Titles[0].Text = $"Top Guests by Spending: {startDate:MMM dd} - {endDate:MMM dd}";
                chartGuestDistribution.ChartAreas[0].AxisY.Minimum = 0;
                chartGuestDistribution.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartGuestDistribution.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Guest Distribution Chart Error: {ex.Message}", "Error");

                series.ChartType = SeriesChartType.Bar;
                series.Color = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "R#,##0";

                series.Points.AddXY("John Smith", 4500);
                series.Points.AddXY("Sarah Johnson", 3800);
                series.Points.AddXY("Mike Wilson", 3200);
                series.Points.AddXY("Emily Brown", 2800);
                series.Points.AddXY("David Lee", 2200);
                series.Points.AddXY("Lisa Davis", 1800);
                series.Points.AddXY("Robert Miller", 1500);
                series.Points.AddXY("Maria Garcia", 1200);
            }

            chartGuestDistribution.Invalidate();
        }

        private Color GetColorBySpending(decimal totalSpent)
        {
            if (totalSpent >= 4000) return Color.DarkGreen;
            if (totalSpent >= 3000) return Color.Green;
            if (totalSpent >= 2000) return Color.LightGreen;
            if (totalSpent >= 1000) return Color.YellowGreen;
            return Color.SteelBlue;
        }
        #endregion

        #region Event Handlers
        private void btnOkay_Click(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality to be implemented", "Print",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 12, 12);
            dtpEndDate.Value = new DateTime(2025, 12, 12);
            LoadCharts();
            SetDateMenuButtonsUI(sender);
        }

        private void btnLastSevenDays_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 12, 5);
            dtpEndDate.Value = new DateTime(2025, 12, 11);
            LoadCharts();
            SetDateMenuButtonsUI(sender);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 12, 1);
            dtpEndDate.Value = new DateTime(2025, 12, 31);
            LoadCharts();
            SetDateMenuButtonsUI(sender);
        }

        private void btnDecember_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 12, 1);
            dtpEndDate.Value = new DateTime(2025, 12, 31);
            LoadCharts();
            SetDateMenuButtonsUI(sender);
        }
        #endregion

        private void MonthlySalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}