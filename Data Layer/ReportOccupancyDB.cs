using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Phumla_Kamnandi.Data_Layer
{
    public class ReportOccupancyDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;";

        public DataTable GetGuestsByRoomType(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ro.RoomType, SUM(r.NumberOfGuests) AS GuestCount
                    FROM RoomAllocation ra
                    JOIN Rooms ro ON ra.RoomID = ro.RoomID
                    JOIN Reservations r ON ra.ReservationID = r.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ro.RoomType
                    ORDER BY ro.RoomType ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetRoomsOccupiedByDay(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ra.DateAllocated, COUNT(ra.RoomID) AS RoomsOccupied
                    FROM RoomAllocation ra
                    JOIN Reservations r ON ra.ReservationID = r.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    GROUP BY ra.DateAllocated
                    ORDER BY ra.DateAllocated ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetDailyDepositCount(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.PaymentDate, COUNT(p.AccountID) AS Guests
                    FROM Payments p
                    JOIN Reservations r ON p.AccountID = r.GuestID
                    WHERE p.PaymentType='Deposit'
                      AND r.ReservationDate BETWEEN @StartDate AND @EndDate
                    GROUP BY p.PaymentDate
                    ORDER BY p.PaymentDate ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public decimal GetTotalDeposits(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT SUM(p.AmountPaid) AS TotalDeposit
                    FROM Payments p
                    JOIN Reservations r ON p.AccountID = r.GuestID
                    WHERE p.PaymentType='Deposit'
                      AND r.ReservationDate BETWEEN @StartDate AND @EndDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }

        public DataTable GetRoomOccupancyForGantt(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ro.RoomNumber, r.CheckInDate, r.CheckOutDate
                    FROM RoomAllocation ra
                    JOIN Rooms ro ON ra.RoomID = ro.RoomID
                    JOIN Reservations r ON ra.ReservationID = r.ReservationID
                    WHERE ra.DateAllocated BETWEEN @StartDate AND @EndDate
                    ORDER BY ro.RoomNumber ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}