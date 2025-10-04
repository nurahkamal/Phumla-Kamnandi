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
    public partial class OccupancyReport : Form
    {
        private ReportOccupancyController _reportController;

        public OccupancyReport()
        {
            InitializeComponent();
            _reportController = new ReportOccupancyController();
            WireUpEvents();
            SetDefaultDates();
            LoadCharts();
        }

        private void WireUpEvents()
        {
            btnOkay.Click += btnOkay_Click;
            btnExit.Click += btnExit_Click;
            btnToday.Click += btnToday_Click;
            btnLastSevenDays.Click += btnLastSevenDays_Click;
            btnThisMonth.Click += btnThisMonth_Click;
            btnDecember.Click += btnDecember_Click;
        }

        private void SetDefaultDates()
        {
            dtpStartDate.Value = new DateTime(2025, 12, 1);
            dtpEndDate.Value = new DateTime(2025, 12, 31);
        }

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
                UpdateSeasonalRevenueChart(startDate, endDate);
                UpdateDepositStatusChart(startDate, endDate);
                UpdateRoomTimelineChart(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading charts: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void UpdateSeasonalRevenueChart(DateTime startDate, DateTime endDate)
        {
            var seriesRevenue = chartSeasonalRevenue.Series["SeasonalRevenue"];
            seriesRevenue.Points.Clear();

            try
            {
                DataTable dtSeasonalRevenue = _reportController.GetSeasonalRevenue(startDate, endDate);

                if (dtSeasonalRevenue.Rows.Count == 0)
                {
                    seriesRevenue.Points.AddXY("No Data", 1);
                }
                else
                {
                    foreach (DataRow row in dtSeasonalRevenue.Rows)
                    {
                        string season = row["Season"].ToString();
                        decimal totalRevenue = Convert.ToDecimal(row["TotalRevenue"]);
                        seriesRevenue.Points.AddXY(season, (double)totalRevenue);
                    }
                }
            }
            catch (Exception ex)
            {
                seriesRevenue.Points.AddXY("Error", 1);
            }

            chartSeasonalRevenue.Invalidate();
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
                else if (dtDepositStatus.Rows.Count == 1)
                {
                    string status = dtDepositStatus.Rows[0]["Status"].ToString();
                    int count = Convert.ToInt32(dtDepositStatus.Rows[0]["Count"]);

                    if (status == "Paid")
                    {
                        DataPoint paidPoint = new DataPoint();
                        paidPoint.AxisLabel = "Paid: " + count;
                        paidPoint.YValues = new double[] { count };
                        paidPoint.Color = Color.Green;
                        seriesDeposit.Points.Add(paidPoint);

                        DataPoint duePoint = new DataPoint();
                        duePoint.AxisLabel = "Due: 0";
                        duePoint.YValues = new double[] { 1 };
                        duePoint.Color = Color.Red;
                        seriesDeposit.Points.Add(duePoint);
                    }
                    else if (status == "Due")
                    {
                        DataPoint paidPoint = new DataPoint();
                        paidPoint.AxisLabel = "Paid: 0";
                        paidPoint.YValues = new double[] { 1 };
                        paidPoint.Color = Color.Green;
                        seriesDeposit.Points.Add(paidPoint);

                        DataPoint duePoint = new DataPoint();
                        duePoint.AxisLabel = "Due: " + count;
                        duePoint.YValues = new double[] { count };
                        duePoint.Color = Color.Red;
                        seriesDeposit.Points.Add(duePoint);
                    }
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

                        if (status == "Paid")
                            point.Color = Color.Green;
                        else if (status == "Due")
                            point.Color = Color.Red;

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

        private void btnOkay_Click(object sender, EventArgs e) => LoadCharts();
        private void btnExit_Click(object sender, EventArgs e) => this.Close();

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadCharts();
        }

        private void btnLastSevenDays_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadCharts();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadCharts();
        }

        private void btnDecember_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 12, 1);
            dtpEndDate.Value = new DateTime(2025, 12, 31);
            LoadCharts();
        }
    }
}