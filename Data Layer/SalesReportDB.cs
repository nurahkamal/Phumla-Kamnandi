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
                    AND res.BookingStatus = 'Confirmed'
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

        #region Chart 2: Seasonal Revenue from Reservations - DYNAMIC
        public DataTable GetSeasonalRevenueData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Calculate season boundaries based on the selected date range
                int totalDays = (endDate - startDate).Days + 1;
                DateTime lowSeasonEnd = startDate.AddDays(totalDays * 1 / 3 - 1);
                DateTime midSeasonEnd = startDate.AddDays(totalDays * 2 / 3 - 1);

                string query = @"
            SELECT 
                CASE 
                    WHEN ra.DateAllocated BETWEEN @StartDate AND @LowSeasonEnd THEN 'Low Season'
                    WHEN ra.DateAllocated BETWEEN DATEADD(DAY, 1, @LowSeasonEnd) AND @MidSeasonEnd THEN 'Mid Season'
                    ELSE 'High Season'
                END as SeasonPeriod,
                SUM(rr.RateApplied) as Revenue
            FROM RoomAllocation ra
            JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
            JOIN Reservations res ON ra.ReservationID = res.ReservationID
            WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
            AND res.BookingStatus = 'Confirmed'
            GROUP BY 
                CASE 
                    WHEN ra.DateAllocated BETWEEN @StartDate AND @LowSeasonEnd THEN 'Low Season'
                    WHEN ra.DateAllocated BETWEEN DATEADD(DAY, 1, @LowSeasonEnd) AND @MidSeasonEnd THEN 'Mid Season'
                    ELSE 'High Season'
                END";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@LowSeasonEnd", lowSeasonEnd);
                cmd.Parameters.AddWithValue("@MidSeasonEnd", midSeasonEnd);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                // Ensure all seasons are represented
                EnsureAllSeasons(dt);

                return dt;
            }
        }

        private void EnsureAllSeasons(DataTable dt)
        {
            var seasons = new[] { "Low Season", "Mid Season", "High Season" };

            foreach (string season in seasons)
            {
                if (!dt.AsEnumerable().Any(row => row["SeasonPeriod"].ToString() == season))
                {
                    dt.Rows.Add(season, 0);
                }
            }
        }
        #endregion

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
                    AND res.BookingStatus = 'Confirmed'
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
                    AND res.BookingStatus = 'Confirmed'
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
            AND res.BookingStatus = 'Confirmed'
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