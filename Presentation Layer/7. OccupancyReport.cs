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
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2025, 12, 1);
            DateTime endDate = new DateTime(2025, 12, 31);

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
                DateTime start = Convert.ToDateTime(row["CheckInDate"]);
                DateTime end = Convert.ToDateTime(row["CheckOutDate"]);
                chartRoomOccupancyOverTime.Series["Occupancy"].Points.AddXY(roomNumber, new double[] { start.ToOADate(), end.ToOADate() });
            }
        }
    }
}