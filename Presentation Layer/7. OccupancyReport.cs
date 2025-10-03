using Guna.UI2.WinForms.Suite;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class OccupancyReport : Form
    {
        private ReportOccupancyController _reportController;

        public OccupancyReport()
        {
            InitializeComponent();
            _reportController = new ReportOccupancyController();

            // Wire up the buttons to their events
            btnOkay.Click += btnOkay_Click;
            btnToday.Click += btnToday_Click;
            btnLast7days.Click += btnLast7days_Click;
            btnLast30Days.Click += btnLast30Days_Click;
            btnLastMonth.Click += btnLastMonth_Click;
        }

        // =================== Report Generation ===================
        private void GenerateReport(DateTime startDate, DateTime endDate)
        {
            // 1️⃣ Rooms by Season (Bar Chart)
            DataTable dtSeason = _reportController.GetRoomsBySeason(startDate, endDate);
            chartRoomsBySeason.Series["Guests"].Points.Clear();
            foreach (DataRow row in dtSeason.Rows)
                chartRoomsBySeason.Series["Guests"].Points.AddXY(row["GuestCount"], row["RoomType"]);

            // 2️⃣ Rooms Occupied by Day (Column Chart)
            DataTable dtRoomsDay = _reportController.GetRoomsOccupiedByDay(startDate, endDate);
            chartRoomsByDay.Series["RoomsOccupied"].Points.Clear();
            foreach (DataRow row in dtRoomsDay.Rows)
                chartRoomsByDay.Series["RoomsOccupied"].Points.AddXY(
                    Convert.ToDateTime(row["DateAllocated"]).ToString("dd/MM"), row["RoomsOccupied"]);

            // 3️⃣ Daily Deposits (Line Chart)
            DataTable dtDailyDeposits = _reportController.GetDailyDeposits(startDate, endDate);
            chartDailyDeposits.Series["DailyDeposits"].Points.Clear();
            foreach (DataRow row in dtDailyDeposits.Rows)
                chartDailyDeposits.Series["DailyDeposits"].Points.AddXY(
                    Convert.ToDateTime(row["PaymentDate"]).ToString("dd/MM"), row["Guests"]);

            // 4️⃣ Pie Chart for Deposits
            chartDeposits.Series["Deposits"].Points.Clear();
            foreach (DataRow row in dtDailyDeposits.Rows)
                chartDeposits.Series["Deposits"].Points.AddXY(
                    Convert.ToDateTime(row["PaymentDate"]).ToString("dd/MM"), row["Guests"]);

            // 5️⃣ Total Deposits
            lblTotalDeposits.Text = "Total Deposits: R " +
                                    _reportController.GetTotalDeposits(startDate, endDate).ToString("N2");

            // 6️⃣ Room Occupancy for Gantt Chart
            DataTable dtGantt = _reportController.GetRoomOccupancyForGantt(startDate, endDate);
            chartRoomOccupancyOverTime.Series["Occupancy"].Points.Clear();
            foreach (DataRow row in dtGantt.Rows)
            {
                string roomNumber = row["RoomNumber"].ToString();
                    DateTime checkIn = Convert.ToDateTime(row["CheckInDate"]);
                    DateTime checkOut = Convert.ToDateTime(row["CheckOutDate"]);

                    var point = new DataPoint();
                    point.AxisLabel = roomNumber;
                    point.YValues = new double[] { checkIn.ToOADate(), checkOut.ToOADate() };
                    seriesGantt.Points.Add(point);
                }

                // Set X-axis as DateTime
                chartRoomOccupancyOverTime.ChartAreas[0].AxisX.Minimum = Convert.ToDateTime(dtGantt.Rows[0]["CheckInDate"]).ToOADate();
                chartRoomOccupancyOverTime.ChartAreas[0].AxisX.Maximum = Convert.ToDateTime(dtGantt.Rows[dtGantt.Rows.Count - 1]["CheckOutDate"]).ToOADate();
                chartRoomOccupancyOverTime.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            }
        }

        // =================== Button Events ===================
        private void btnOkay_Click(object sender, EventArgs e)
        {
            GenerateReport(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            GenerateReport(today, today);
        }

        private void btnLast7days_Click(object sender, EventArgs e)
        {
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-6);
            GenerateReport(startDate, endDate);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-29);
            GenerateReport(startDate, endDate);
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            DateTime firstDayLastMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            DateTime lastDayLastMonth = firstDayLastMonth.AddMonths(1).AddDays(-1);
            GenerateReport(firstDayLastMonth, lastDayLastMonth);
        }
    }
}