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

        #region Chart 2: Seasonal Revenue from Reservations
        public DataTable GetSeasonalRevenueData(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 'Low Season' as SeasonPeriod,
                           ISNULL(SUM(rr.RateApplied), 0) as Revenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN '2025-12-01' AND '2025-12-07'
                    AND res.BookingStatus = 'Confirmed'
                    
                    UNION ALL
                    
                    SELECT 'Mid Season' as SeasonPeriod,
                           ISNULL(SUM(rr.RateApplied), 0) as Revenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN '2025-12-08' AND '2025-12-15'
                    AND res.BookingStatus = 'Confirmed'
                    
                    UNION ALL
                    
                    SELECT 'High Season' as SeasonPeriod,
                           ISNULL(SUM(rr.RateApplied), 0) as Revenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.ReservationID = rr.ReservationID AND ra.RoomID = rr.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN '2025-12-16' AND '2025-12-31'
                    AND res.BookingStatus = 'Confirmed'";

                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
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