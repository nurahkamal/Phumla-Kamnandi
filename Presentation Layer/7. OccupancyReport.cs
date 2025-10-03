using Guna.UI2.WinForms.Suite;
using Phumla_Kamnandi.Business_Layer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phumla_Kamnandi.Presentation_Layer
{
    public partial class _7OccupancyReport : Form
    {
        private ReportOccupancyController _reportController;

        public _7OccupancyReport()
        {
            InitializeComponent();
            _reportController = new ReportOccupancyController();

            CreateSeries(chartRoomsBySeason, "Guests", SeriesChartType.Bar, Color.CornflowerBlue);
            CreateSeries(chartRoomsByDay, "RoomsOccupied", SeriesChartType.Column, Color.MediumSeaGreen);
            CreateSeries(chartDailyDeposits, "DailyDeposits", SeriesChartType.Line, Color.OrangeRed);
            CreateSeries(chartDeposits, "Deposits", SeriesChartType.Pie, Color.Purple);
            CreateSeries(chartRoomOccupancyOverTime, "Occupancy", SeriesChartType.RangeBar, Color.SkyBlue);

            btnOkay.Click += btnOkay_Click;
            btnToday.Click += btnToday_Click;
            btnLast7days.Click += btnLast7days_Click;
            btnLast30Days.Click += btnLast30Days_Click;
            btnLastMonth.Click += btnLastMonth_Click;
            btnExit.Click += btnExit_Click;
        }

        private void CreateSeries(Chart chart, string name, SeriesChartType type, Color color)
        {
            if (chart.Series.IndexOf(name) == -1)
                chart.Series.Add(name);
            var series = chart.Series[name];
            series.ChartType = type;
            series.IsValueShownAsLabel = false;
            series.Color = color;
        }

        private void GenerateReport(DateTime startDate, DateTime endDate)
        {
            DataTable dtSeason = _reportController.GetRoomsBySeason(startDate, endDate);
            DataTable dtRoomsDay = _reportController.GetRoomsOccupiedByDay(startDate, endDate);
            // Modified: Fetch deposits grouped by date and summed total deposits based on SQL above
            DataTable dtDeposits = _reportController.GetDailyDeposits(startDate, endDate);
            DataTable dtGantt = _reportController.GetRoomOccupancyForGantt(startDate, endDate);

            // Rooms By Season Bar Chart
            var seriesGuests = chartRoomsBySeason.Series["Guests"];
            seriesGuests.Points.Clear();
            if (dtSeason.Rows.Count == 0)
                seriesGuests.Points.AddXY("No Data", 0);
            else
                foreach (DataRow row in dtSeason.Rows)
                    seriesGuests.Points.AddXY(row["RoomType"].ToString(), Convert.ToInt32(row["GuestCount"]));

            // Rooms Occupied By Day Column Chart
            var seriesRoomsDay = chartRoomsByDay.Series["RoomsOccupied"];
            seriesRoomsDay.Points.Clear();
            foreach (DataRow row in dtRoomsDay.Rows)
            {
                var dateLabel = Convert.ToDateTime(row["DateAllocated"]).ToString("dd/MM");
                var rooms = Convert.ToInt32(row["RoomsOccupied"]);
                var point = new DataPoint { AxisLabel = dateLabel, YValues = new double[] { rooms } };
                if (dateLabel == DateTime.Today.ToString("dd/MM"))
                    point.Color = Color.Red;
                seriesRoomsDay.Points.Add(point);
            }
            if (seriesRoomsDay.Points.Count == 0)
                seriesRoomsDay.Points.AddXY("No Data", 0);

            // Daily Deposits Line Chart - updated to use TotalDeposit
            var seriesLine = chartDailyDeposits.Series["DailyDeposits"];
            seriesLine.Points.Clear();
            seriesLine.XValueType = ChartValueType.DateTime;
            chartDailyDeposits.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chartDailyDeposits.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chartDailyDeposits.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartDailyDeposits.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            foreach (DataRow row in dtDeposits.Rows)
            {
                DateTime date = Convert.ToDateTime(row["PaymentDate"]);
                double totalDeposit = Convert.ToDouble(row["TotalDeposit"]);
                var point = new DataPoint
                {
                    XValue = date.ToOADate(),
                    YValues = new double[] { totalDeposit }
                };
                seriesLine.Points.Add(point);
            }
            if (seriesLine.Points.Count == 0)
                seriesLine.Points.AddXY(DateTime.Today.ToOADate(), 0);

            // Deposits Pie Chart
            var seriesPie = chartDeposits.Series["Deposits"];
            seriesPie.Points.Clear();
            foreach (DataRow row in dtDeposits.Rows)
            {
                DateTime date = Convert.ToDateTime(row["PaymentDate"]);
                double totalDeposit = Convert.ToDouble(row["TotalDeposit"]);
                seriesPie.Points.AddXY(date.ToString("dd/MM"), totalDeposit);
            }
            if (seriesPie.Points.Count == 0)
                seriesPie.Points.AddXY("No Data", 1);

            lblTotalDeposits.Text = "Total Deposits: R " + _reportController.GetTotalDeposits(startDate, endDate).ToString("N2");

            // Room Occupancy Gantt Chart with range bars
            var yAxis = chartRoomOccupancyOverTime.ChartAreas[0].AxisY;
            yAxis.LabelStyle.Format = "dd/MM";
            yAxis.MajorGrid.LineColor = Color.LightGray;
            yAxis.IntervalType = DateTimeIntervalType.Days;
            yAxis.IsStartedFromZero = false;

            var seriesGantt = chartRoomOccupancyOverTime.Series["Occupancy"];
            seriesGantt.Points.Clear();
            seriesGantt.ChartType = SeriesChartType.RangeBar;
            seriesGantt.YValueType = ChartValueType.DateTime;

            foreach (DataRow row in dtGantt.Rows)
            {
                string roomNumber = row["RoomNumber"].ToString();
                DateTime checkIn = Convert.ToDateTime(row["CheckInDate"]);
                DateTime checkOut = Convert.ToDateTime(row["CheckOutDate"]);

                if (checkOut <= checkIn)
                    continue;

                var point = new DataPoint
                {
                    AxisLabel = roomNumber,
                    YValues = new double[] { checkIn.ToOADate(), checkOut.ToOADate() }
                };
                seriesGantt.Points.Add(point);
            }
            if (seriesGantt.Points.Count == 0)
            {
                var emptyPoint = new DataPoint
                {
                    AxisLabel = "No Data",
                    YValues = new double[] { DateTime.Today.ToOADate(), DateTime.Today.ToOADate() }
                };
                seriesGantt.Points.Add(emptyPoint);
            }

            // Refresh charts
            chartDailyDeposits.Invalidate();
            chartDailyDeposits.Update();

            chartRoomOccupancyOverTime.Invalidate();
            chartRoomOccupancyOverTime.Update();
        }

        // Button click event handlers
        private void btnOkay_Click(object sender, EventArgs e) => GenerateReport(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        private void btnToday_Click(object sender, EventArgs e) => GenerateReport(DateTime.Today, DateTime.Today);
        private void btnLast7days_Click(object sender, EventArgs e) => GenerateReport(DateTime.Today.AddDays(-6), DateTime.Today);
        private void btnLast30Days_Click(object sender, EventArgs e) => GenerateReport(DateTime.Today.AddDays(-29), DateTime.Today);
        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            var firstDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);
            GenerateReport(firstDay, lastDay);
        }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        private void _7OccupancyReport_Load(object sender, EventArgs e) => GenerateReport(DateTime.Today, DateTime.Today);
    }
}
