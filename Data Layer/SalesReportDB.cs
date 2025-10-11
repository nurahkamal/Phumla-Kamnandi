using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    public class SalesReportDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        #region Chart 1: Expected Revenue from Reservations 
        public DataTable GetExpectedRevenueTrend(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ra.DateAllocated as BookingDate,
                        SUM(rr.RateApplied) as DailyRevenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Chart 2: Seasonal Revenue from Reservations - FIXED FOR PARTIAL HIGH SEASON
        public DataTable GetSeasonalRevenueData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                CASE 
                    WHEN ra.DateAllocated BETWEEN '2025-12-01' AND '2025-12-07' THEN 'Low Season'
                    WHEN ra.DateAllocated BETWEEN '2025-12-08' AND '2025-12-15' THEN 'Mid Season'
                    WHEN ra.DateAllocated >= '2025-12-16' THEN 'High Season'
                    ELSE 'Other'
                END as SeasonPeriod,
                SUM(rr.RateApplied) as Revenue
            FROM RoomAllocation ra
            JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
            JOIN Reservations res ON ra.ReservationID = res.ReservationID
            WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
            GROUP BY 
                CASE 
                    WHEN ra.DateAllocated BETWEEN '2025-12-01' AND '2025-12-07' THEN 'Low Season'
                    WHEN ra.DateAllocated BETWEEN '2025-12-08' AND '2025-12-15' THEN 'Mid Season'
                    WHEN ra.DateAllocated >= '2025-12-16' THEN 'High Season'
                    ELSE 'Other'
                END";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                // Ensure all seasons within the selected date range are represented
                return EnsureSeasonsForDateRange(dt, startDate, endDate);
            }
        }

        private DataTable EnsureSeasonsForDateRange(DataTable dt, DateTime startDate, DateTime endDate)
        {
            // Create a new table with correct season order
            DataTable orderedDt = new DataTable();
            orderedDt.Columns.Add("SeasonPeriod", typeof(string));
            orderedDt.Columns.Add("Revenue", typeof(decimal));

            // Define the seasons that should appear based on the date range
            var seasonsToShow = GetSeasonsInDateRange(startDate, endDate);

            foreach (string season in seasonsToShow)
            {
                DataRow[] rows = dt.Select($"SeasonPeriod = '{season}'");
                if (rows.Length > 0)
                {
                    orderedDt.ImportRow(rows[0]);
                }
                else
                {
                    // Add season with zero revenue if it should be in the range but has no data
                    orderedDt.Rows.Add(season, 0);
                }
            }

            return orderedDt;
        }

        private List<string> GetSeasonsInDateRange(DateTime startDate, DateTime endDate)
        {
            var seasonsInRange = new List<string>();

            DateTime lowSeasonStart = new DateTime(2025, 12, 1);
            DateTime lowSeasonEnd = new DateTime(2025, 12, 7);
            DateTime midSeasonStart = new DateTime(2025, 12, 8);
            DateTime midSeasonEnd = new DateTime(2025, 12, 15);
            DateTime highSeasonStart = new DateTime(2025, 12, 16);
            DateTime highSeasonEnd = new DateTime(2025, 12, 31);

            // Check if date range includes any Low Season days
            if (startDate <= lowSeasonEnd && endDate >= lowSeasonStart)
                seasonsInRange.Add("Low Season");

            // Check if date range includes any Mid Season days
            if (startDate <= midSeasonEnd && endDate >= midSeasonStart)
                seasonsInRange.Add("Mid Season");

            // Check if date range includes any High Season days
            if (startDate <= highSeasonEnd && endDate >= highSeasonStart)
                seasonsInRange.Add("High Season");

            return seasonsInRange;
        }

        #region Chart 3: Daily Revenue (Column Chart)
        public DataTable GetDailyRevenueData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ra.DateAllocated as BookingDate,
                        SUM(rr.RateApplied) as DailyRevenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Chart 4: Bookings by Date (Area Chart)
        public DataTable GetBookingsByDateData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ra.DateAllocated as BookingDate,
                        COUNT(DISTINCT ra.ReservationID) as BookingsCount,
                        SUM(rr.RateApplied) as TotalRevenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Chart 5: Guest Count Distribution
        public DataTable GetGuestDistributionData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        res.GuestID,
                        g.FirstName + ' ' + g.LastName as GuestName,
                        COUNT(ra.ReservationID) as BookingCount,
                        SUM(rr.RateApplied) as TotalSpent
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    JOIN Guests g ON res.GuestID = g.GuestID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY res.GuestID, g.FirstName, g.LastName
                    ORDER BY TotalSpent DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
#endregion