using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class MonthlySalesReport : Form
    {
        private SalesReportController _salesController;
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public MonthlySalesReport()
        {
            InitializeComponent();
            _salesController = new SalesReportController();
            InitializePrinting();
            WireUpEvents();
            SetDefaultDates();
            LoadCharts();
            SetActiveDateButton(btnThisMonth);
        }

        #region Printing Setup
        private void InitializePrinting()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
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
            btnPrintSummary.Click += btnPrintSummary_Click;
        }
        #endregion

        #region Button Group Management
        private void SetActiveDateButton(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            var dateButtons = new List<Guna.UI2.WinForms.Guna2Button>
            {
                btnToday, btnLastSevenDays, btnThisMonth, btnDecember
            };

            foreach (var button in dateButtons)
            {
                if (button == activeButton)
                {
                    button.Checked = true;
                }
                else
                {
                    button.Checked = false;
                }
            }
        }
        #endregion

        #region Date config
        private DateTime GetDecemberDate()
        {
            return new DateTime(2025, 12, 12);
        }

        private void SetDefaultDates()
        {
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = fakeToday.AddDays(-30);
            dtpEndDate.Value = fakeToday;
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

                foreach (DataRow row in seasonalData.Rows)
                {
                    string season = row["SeasonPeriod"].ToString();
                    decimal revenue = Convert.ToDecimal(row["Revenue"]);

                    DataPoint point = new DataPoint();
                    point.SetValueXY(season, (double)revenue);
                    point.Label = $"{season}\nR{revenue:#,##0}";

                    series.Points.Add(point);
                }

                chartSeasonalRevenue.Titles[0].Text = $"Revenue by Season: {startDate:MMM dd} - {endDate:MMM dd}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seasonal Revenue Chart Error: {ex.Message}", "Error");
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
            }

            chartGuestDistribution.Invalidate();
        }
        #endregion

        #region Print and Export Functions
        private void PrintScreenshot()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
                {
                    this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += (s, e) =>
                    {
                        e.Graphics.DrawImage(bitmap, e.MarginBounds);
                    };

                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDocument;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                        MessageBox.Show("Report sent to printer successfully!", "Print Complete",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}", "Print Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPrintPreview()
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print preview error: {ex.Message}", "Print Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            Font smallFont = new Font("Segoe UI", 8);

            float yPos = 50;
            float leftMargin = 50;

            string title = "Phumla Kamnandi Hotels - Sales Report";
            graphics.DrawString(title, titleFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            string dateRange = $"Date Range: {dtpStartDate.Value:dd MMM yyyy} to {dtpEndDate.Value:dd MMM yyyy}";
            graphics.DrawString(dateRange, headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            string printDate = $"Printed: {GetDecemberDate():dd MMM yyyy HH:mm}";
            graphics.DrawString(printDate, smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            graphics.DrawString("Chart Summaries:", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            string[] summaries = {
                "• Expected Revenue Trend: Shows daily revenue from confirmed bookings",
                "• Seasonal Revenue: Displays revenue distribution across seasons",
                "• Daily Revenue: Column chart of daily revenue amounts",
                "• Bookings by Date: Area chart showing booking frequency",
                "• Guest Distribution: Top guests by total spending"
            };

            foreach (string summary in summaries)
            {
                graphics.DrawString(summary, normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += 20;
            }

            yPos += 30;

            try
            {
                DataTable seasonalData = _salesController.GetSeasonalRevenueData(dtpStartDate.Value, dtpEndDate.Value);
                if (seasonalData.Rows.Count > 0)
                {
                    graphics.DrawString("Seasonal Revenue Summary:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 25;

                    foreach (DataRow row in seasonalData.Rows)
                    {
                        string season = row["SeasonPeriod"].ToString();
                        decimal revenue = Convert.ToDecimal(row["Revenue"]);
                        string seasonSummary = $"{season}: R{revenue:#,##0}";
                        graphics.DrawString(seasonSummary, normalFont, Brushes.Black, leftMargin + 20, yPos);
                        yPos += 20;
                    }
                }
            }
            catch
            {
            }

            yPos += 30;

            try
            {
                DataTable guestData = _salesController.GetGuestDistributionData(dtpStartDate.Value, dtpEndDate.Value);
                if (guestData.Rows.Count > 0)
                {
                    graphics.DrawString("Top 5 Guests by Spending:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 25;

                    int count = 0;
                    foreach (DataRow row in guestData.Rows)
                    {
                        if (count >= 5) break;

                        string guestName = row["GuestName"].ToString();
                        decimal totalSpent = Convert.ToDecimal(row["TotalSpent"]);
                        string guestSummary = $"{guestName}: R{totalSpent:#,##0}";
                        graphics.DrawString(guestSummary, normalFont, Brushes.Black, leftMargin + 20, yPos);
                        yPos += 20;
                        count++;
                    }
                }
            }
            catch
            {
            }

            yPos = e.PageBounds.Height - 50;
            string footer = "Confidential - Phumla Kamnandi Hotels Internal Use Only";
            graphics.DrawString(footer, smallFont, Brushes.Gray, leftMargin, yPos);
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
            PrintScreenshot();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            ShowPrintPreview();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetActiveDateButton(btnToday);
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = fakeToday;
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnLastSevenDays_Click(object sender, EventArgs e)
        {
            SetActiveDateButton(btnLastSevenDays);
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = fakeToday.AddDays(-6);
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            SetActiveDateButton(btnThisMonth);
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = new DateTime(fakeToday.Year, fakeToday.Month, 1);
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnDecember_Click(object sender, EventArgs e)
        {
            SetActiveDateButton(btnDecember);
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = new DateTime(fakeToday.Year, 12, 1);
            dtpEndDate.Value = new DateTime(fakeToday.Year, 12, 31);
            LoadCharts();
        }
        #endregion
    }
}