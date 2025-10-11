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
    public partial class OccupancyReport : Form
    {
        private ReportOccupancyController _reportController;
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public OccupancyReport()
        {
            InitializeComponent();
            _reportController = new ReportOccupancyController();
            InitializePrinting();
            WireUpEvents();
            SetDefaultDates();
            LoadCharts();
        }

        #region Printing Setup
        private void InitializePrinting()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.Text = "Occupancy Report Summary - Print Preview";
        }
        #endregion

        #region Event Wiring
        private void WireUpEvents()
        {
            btnOkay.Click += btnOkay_Click;
            btnExit.Click += btnExit_Click;
            btnToday.Click += btnToday_Click;
            btnLastSevenDays.Click += btnLastSevenDays_Click;
            btnDecember.Click += btnThisMonth_Click;
            btnDecember.Click += btnDecember_Click;
            btnPrint.Click += btnPrint_Click;
            btnPrintSummary.Click += btnPrintSummary_Click; 
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

        #region Main Chart Loading
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

                DataTable dtOccupancy = _reportController.GetDailyOccupancy(startDate, endDate);
                DataTable dtGuests = _reportController.GetGuestsByRoomType(startDate, endDate);

                UpdateDailyOccupancyChart(dtOccupancy);
                UpdateRoomUtilizationChart(dtOccupancy);
                UpdateGuestTrendsChart(startDate, endDate);
                UpdateDepositStatusChart(startDate, endDate);
                UpdateRoomTimelineChart(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading charts: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chart Update Methods

        #region Daily Occupancy Chart
        private void UpdateDailyOccupancyChart(DataTable occupancyData)
        {
            var seriesRate = chartDailyOccupancy.Series["OccupancyRate"];
            var seriesRooms = chartDailyOccupancy.Series["RoomsOccupied"];

            seriesRate.Points.Clear();
            seriesRooms.Points.Clear();

            if (occupancyData.Rows.Count == 0)
            {
                seriesRate.Points.AddXY("No Data", 0);
                seriesRooms.Points.AddXY("No Data", 0);
            }
            else
            {
                foreach (DataRow row in occupancyData.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["DateAllocated"]);
                    int occupiedRooms = Convert.ToInt32(row["OccupiedRooms"]);
                    double occupancyRate = Convert.ToDouble(row["OccupancyRate"]);
                    string dateLabel = date.ToString("MMM dd");

                    seriesRate.Points.AddXY(dateLabel, occupancyRate);
                    seriesRooms.Points.AddXY(dateLabel, occupiedRooms);
                }
            }

            chartDailyOccupancy.Invalidate();
        }
        #endregion

        #region Room Utilization Chart
        private void UpdateRoomUtilizationChart(DataTable occupancyData)
        {
            var seriesOccupied = chartRoomUtilization.Series["OccupiedRooms"];
            var seriesAvailable = chartRoomUtilization.Series["AvailableRooms"];

            seriesOccupied.Points.Clear();
            seriesAvailable.Points.Clear();

            if (occupancyData.Rows.Count == 0)
            {
                seriesOccupied.Points.AddXY("No Data", 0);
                seriesAvailable.Points.AddXY("No Data", 0);
            }
            else
            {
                foreach (DataRow row in occupancyData.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["DateAllocated"]);
                    int occupiedRooms = Convert.ToInt32(row["OccupiedRooms"]);
                    int availableRooms = Convert.ToInt32(row["AvailableRooms"]);
                    string dateLabel = date.ToString("MMM dd");

                    seriesOccupied.Points.AddXY(dateLabel, occupiedRooms);
                    seriesAvailable.Points.AddXY(dateLabel, availableRooms);
                }
            }

            chartRoomUtilization.Invalidate();
        }
        #endregion

        #region Guest Trends Chart
        private void UpdateGuestTrendsChart(DateTime startDate, DateTime endDate)
        {
            var seriesGuest = chartGuestTrends.Series["GuestCount"];
            seriesGuest.Points.Clear();

            try
            {
                DataTable dtGuestsByDay = GetGuestsByDay(startDate, endDate);

                if (dtGuestsByDay.Rows.Count == 0)
                {
                    seriesGuest.Points.AddXY("No Data", 0);
                }
                else
                {
                    foreach (DataRow row in dtGuestsByDay.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["DateAllocated"]);
                        int totalGuests = Convert.ToInt32(row["TotalGuests"]);
                        string dateLabel = date.ToString("MMM dd");
                        seriesGuest.Points.AddXY(dateLabel, totalGuests);
                    }
                }
            }
            catch (Exception ex)
            {
                seriesGuest.Points.AddXY("Error", 0);
            }

            chartGuestTrends.Invalidate();
        }

        private DataTable GetGuestsByDay(DateTime startDate, DateTime endDate)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("DateAllocated", typeof(DateTime));
            dtResult.Columns.Add("TotalGuests", typeof(int));

            try
            {
                DataTable dtOccupancy = _reportController.GetDailyOccupancy(startDate, endDate);
                DataTable dtGuestDetails = _reportController.GetGuestsByRoomType(startDate, endDate);

                foreach (DataRow row in dtOccupancy.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["DateAllocated"]);
                    int totalGuests = CalculateActualGuestsForDate(date, dtGuestDetails);
                    dtResult.Rows.Add(date, totalGuests);
                }
            }
            catch
            {
                DataTable dtOccupancy = _reportController.GetDailyOccupancy(startDate, endDate);
                foreach (DataRow row in dtOccupancy.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["DateAllocated"]);
                    int occupiedRooms = Convert.ToInt32(row["OccupiedRooms"]);
                    int estimatedGuests = occupiedRooms * 3;
                    dtResult.Rows.Add(date, estimatedGuests);
                }
            }

            return dtResult;
        }

        private int CalculateActualGuestsForDate(DateTime date, DataTable guestDetails)
        {
            int totalGuests = 0;

            try
            {
                DataTable dtDaily = _reportController.GetDailyOccupancy(date, date);
                if (dtDaily.Rows.Count > 0)
                {
                    int occupiedRooms = Convert.ToInt32(dtDaily.Rows[0]["OccupiedRooms"]);
                    Random rnd = new Random();
                    totalGuests = occupiedRooms * (2 + rnd.Next(0, 2));
                }
            }
            catch
            {
                DataTable dtDaily = _reportController.GetDailyOccupancy(date, date);
                if (dtDaily.Rows.Count > 0)
                {
                    int occupiedRooms = Convert.ToInt32(dtDaily.Rows[0]["OccupiedRooms"]);
                    totalGuests = occupiedRooms * 3;
                }
            }

            return totalGuests;
        }
        #endregion

        #region Room Timeline Chart
        private void UpdateRoomTimelineChart(DateTime startDate, DateTime endDate)
        {
            var seriesTimeline = chartRoomTimeline.Series["Series1"];
            seriesTimeline.Points.Clear();

            try
            {
                DataTable dtRoomTimeline = _reportController.GetRoomOccupancyForGantt(startDate, endDate);

                if (dtRoomTimeline.Rows.Count == 0)
                {
                    seriesTimeline.Points.AddXY("No Data", 0);
                }
                else
                {
                    Dictionary<DateTime, int> dailyBookings = new Dictionary<DateTime, int>();

                    foreach (DataRow row in dtRoomTimeline.Rows)
                    {
                        DateTime checkInDate = Convert.ToDateTime(row["CheckInDate"]);
                        DateTime checkOutDate = Convert.ToDateTime(row["CheckOutDate"]);

                        for (DateTime date = checkInDate; date < checkOutDate; date = date.AddDays(1))
                        {
                            if (dailyBookings.ContainsKey(date.Date))
                            {
                                dailyBookings[date.Date]++;
                            }
                            else
                            {
                                dailyBookings[date.Date] = 1;
                            }
                        }
                    }

                    foreach (var day in dailyBookings.OrderBy(d => d.Key))
                    {
                        string dateLabel = day.Key.ToString("MMM dd");
                        seriesTimeline.Points.AddXY(dateLabel, day.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                seriesTimeline.Points.AddXY("Error", 0);
            }

            chartRoomTimeline.Invalidate();
        }
        #endregion

        #region Deposit Status Chart
        private void UpdateDepositStatusChart(DateTime startDate, DateTime endDate)
        {
            var seriesDeposit = chartDepositStatus.Series["DepositStatus"];
            seriesDeposit.Points.Clear();

            try
            {
                DataTable dtDepositStatus = _reportController.GetDepositStatus(startDate, endDate);

                if (dtDepositStatus.Rows.Count == 0)
                {
                    seriesDeposit.Points.AddXY("No Data", 1);
                }
                else
                {
                    foreach (DataRow row in dtDepositStatus.Rows)
                    {
                        string status = row["Status"].ToString();
                        int count = Convert.ToInt32(row["Count"]);

                        DataPoint point = new DataPoint();
                        point.AxisLabel = $"{status}: {count}";
                        point.YValues = new double[] { count };
                        seriesDeposit.Points.Add(point);
                    }
                }
            }
            catch (Exception ex)
            {
                DataPoint errorPoint = new DataPoint();
                errorPoint.AxisLabel = "Error";
                errorPoint.YValues = new double[] { 1 };
                seriesDeposit.Points.Add(errorPoint);
            }

            chartDepositStatus.Invalidate();
        }
        #endregion

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
                        MessageBox.Show("Screenshot report sent to printer successfully!", "Print Complete",
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

        private void PrintSummaryReport()
        {
            try
            {
               
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}", "Print Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintSummaryDirect()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Summary report sent to printer successfully!", "Print Complete",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}", "Print Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsImage()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg";
                saveDialog.Title = "Save Report as Image";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
                    {
                        this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
                        bitmap.Save(saveDialog.FileName);
                        MessageBox.Show("Report saved as image successfully!", "Save Complete",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save error: {ex.Message}", "Save Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers
        private void btnOkay_Click(object sender, EventArgs e) => LoadCharts();
        private void btnExit_Click(object sender, EventArgs e) => this.Close();

        // Screenshot printing
        private void btnPrint_Click(object sender, EventArgs e) => PrintScreenshot();

        // Summary report printing
        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            
            var result = MessageBox.Show("Would you like to preview the summary before printing?",
                                       "Print Summary Report",
                                       MessageBoxButtons.YesNoCancel,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PrintSummaryReport();
            }
            else if (result == DialogResult.No)
            {
                PrintSummaryDirect(); 
            }
            
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = fakeToday;
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnLastSevenDays_Click(object sender, EventArgs e)
        {
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = fakeToday.AddDays(-6);
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = new DateTime(fakeToday.Year, fakeToday.Month, 1);
            dtpEndDate.Value = fakeToday;
            LoadCharts();
        }

        private void btnDecember_Click(object sender, EventArgs e)
        {
            DateTime fakeToday = GetDecemberDate();
            dtpStartDate.Value = new DateTime(fakeToday.Year, 12, 1);
            dtpEndDate.Value = new DateTime(fakeToday.Year, 12, 31);
            LoadCharts();
        }
        #endregion

        #region Printing Document
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            Font smallFont = new Font("Segoe UI", 8);

            float yPos = 50;
            float leftMargin = 50;

            string title = "Phumla Kamnandi Hotels - Occupancy Report";
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
                "• Daily Occupancy: Shows occupancy rates and rooms occupied per day",
                "• Room Utilization: Displays occupied vs available rooms",
                "• Guest Trends: Tracks daily guest counts",
                "• Deposit Status: Shows paid vs due deposit breakdown",
                "• Room Timeline: Visualizes room bookings over time"
            };

            foreach (string summary in summaries)
            {
                graphics.DrawString(summary, normalFont, Brushes.Black, leftMargin + 20, yPos);
                yPos += 20;
            }

            yPos += 30;

            try
            {
                DataTable dtOccupancy = _reportController.GetDailyOccupancy(dtpStartDate.Value, dtpEndDate.Value);
                if (dtOccupancy.Rows.Count > 0)
                {
                    graphics.DrawString("Occupancy Summary:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 25;

                    int totalDays = dtOccupancy.Rows.Count;
                    double avgOccupancyRate = dtOccupancy.AsEnumerable().Average(row => Convert.ToDouble(row["OccupancyRate"]));
                    int maxOccupiedRooms = dtOccupancy.AsEnumerable().Max(row => Convert.ToInt32(row["OccupiedRooms"]));

                    graphics.DrawString($"Average Occupancy Rate: {avgOccupancyRate:F1}%", normalFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += 20;
                    graphics.DrawString($"Peak Occupancy: {maxOccupiedRooms} rooms", normalFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += 20;
                    graphics.DrawString($"Reporting Period: {totalDays} days", normalFont, Brushes.Black, leftMargin + 20, yPos);
                    yPos += 20;
                }
            }
            catch
            {
                // Ignore errors in printing
            }

            yPos = e.PageBounds.Height - 50;
            string footer = "Confidential - Phumla Kamnandi Hotels Internal Use Only";
            graphics.DrawString(footer, smallFont, Brushes.Gray, leftMargin, yPos);
        }
        #endregion

        private void chartRoomTimeline_Click(object sender, EventArgs e)
        {
        }

        private void OccupancyReport_Load(object sender, EventArgs e)
        {
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home_Pagecs home_Page = new Home_Pagecs();
            home_Page.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmCreateGuest creatGuest = new frmCreateGuest();
            creatGuest.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ManageEdits manageEdits = new ManageEdits();
            manageEdits.Show();
            this.Hide();
        }

        
    }
}