using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Data_Layer
{
    public class ReportOccupancyDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        #region Daily Occupancy Data
        public DataTable GetDailyOccupancy(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ra.DateAllocated,
                        COUNT(ra.RoomID) as OccupiedRooms,
                        (SELECT COUNT(*) FROM Rooms WHERE Status != 'OutOfService') - COUNT(ra.RoomID) as AvailableRooms,
                        (COUNT(ra.RoomID) * 100.0 / (SELECT COUNT(*) FROM Rooms WHERE Status != 'OutOfService')) as OccupancyRate
                    FROM RoomAllocation ra
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Guests by Room Type
        public DataTable GetGuestsByRoomType(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        r.RoomType, 
                        SUM(rr.NumberOfGuests) as GuestCount
                    FROM RoomAllocation ra
                    JOIN Rooms r ON ra.RoomID = r.RoomID
                    JOIN ReservationRooms rr ON ra.RoomID = rr.RoomID AND ra.ReservationID = rr.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY r.RoomType
                    ORDER BY r.RoomType ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Rooms Occupied By Day
        public DataTable GetRoomsOccupiedByDay(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ra.DateAllocated, 
                        COUNT(ra.RoomID) as RoomsOccupied
                    FROM RoomAllocation ra
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Daily Deposit Count
        public DataTable GetDailyDepositCount(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.PaymentDate, 
                        COUNT(*) as GuestCount
                    FROM Payments p
                    WHERE p.PaymentType = 'Deposit'
                      AND p.PaymentDate BETWEEN @StartDate AND @EndDate
                    GROUP BY p.PaymentDate
                    ORDER BY p.PaymentDate ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Room Occupancy for Gantt Chart
        public DataTable GetRoomOccupancyForGantt(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ro.RoomNumber, 
                        res.CheckInDate, 
                        res.CheckOutDate
                    FROM RoomAllocation ra
                    JOIN Rooms ro ON ra.RoomID = ro.RoomID
                    JOIN Reservations res ON ra.ReservationID = res.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ro.RoomNumber, res.CheckInDate, res.CheckOutDate
                    ORDER BY ro.RoomNumber ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Seasonal Revenue
        public DataTable GetSeasonalRevenue(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        CASE 
                            WHEN ra.DateAllocated BETWEEN '2025-12-01' AND '2025-12-07' THEN 'Low Season'
                            WHEN ra.DateAllocated BETWEEN '2025-12-08' AND '2025-12-15' THEN 'Mid Season' 
                            ELSE 'High Season'
                        END as Season,
                        COUNT(DISTINCT ra.ReservationID) as BookingCount,
                        SUM(rr.RateApplied) as TotalRevenue
                    FROM RoomAllocation ra
                    JOIN ReservationRooms rr ON ra.RoomID = rr.RoomID AND ra.ReservationID = rr.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY CASE 
                        WHEN ra.DateAllocated BETWEEN '2025-12-01' AND '2025-12-07' THEN 'Low Season'
                        WHEN ra.DateAllocated BETWEEN '2025-12-08' AND '2025-12-15' THEN 'Mid Season' 
                        ELSE 'High Season'
                    END";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Deposit Status - FIXED WITH CORRECT COLUMNS
        public DataTable GetDepositStatus(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // FIXED QUERY - Using your actual column names and data
                string query = @"
            SELECT 
                'Paid' as Status,
                COUNT(*) as Count
            FROM Reservations 
            WHERE PaymentStatus = 'Paid'
              AND CheckInDate BETWEEN @StartDate AND @EndDate
            UNION ALL
            SELECT 
                'Due' as Status,
                COUNT(*) as Count
            FROM Reservations 
            WHERE PaymentStatus = 'Outstanding'
              AND CheckInDate BETWEEN @StartDate AND @EndDate";

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
