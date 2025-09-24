using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Phumla_Kamnandi.Business_Layer
{
    public class ReportController : ReportDB
    {
        #region Fields
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;
        #endregion

        #region Properties
        public int NumberOfReservations { get; private set; }
        public int NumberOfGuests { get; private set; }
        public int NumberOfAccounts { get; private set; }
        public List<RevenueByDate> RevenueSummary { get; private set; }
        public decimal TotalRevenue { get; private set; }
        public decimal TotalDeposits { get; private set; }
        #endregion

        #region Constructor
        public ReportController()
        {
            RevenueSummary = new List<RevenueByDate>();
        }
        #endregion

        #region Private Methods - Data Retrieval
        private void GetSummaryData()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    #region Number of Reservations
                    command.CommandText = @"SELECT COUNT(ReservationID)
                                            FROM Reservations
                                            WHERE CheckInDate BETWEEN @fromDate AND @toDate";
                    command.Parameters.AddWithValue("@fromDate", startDate);
                    command.Parameters.AddWithValue("@toDate", endDate);
                    NumberOfReservations = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    #endregion

                    #region Number of Guests
                    command.CommandText = @"SELECT COUNT(GuestID) FROM Guests";
                    NumberOfGuests = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    #endregion

                    #region Number of Travel Agencies
                    command.CommandText = @"SELECT COUNT(TravelAgencyID) FROM TravelAgency";
                    NumberOfAccounts = (int)command.ExecuteScalar();
                    #endregion
                }
            }
        }

        private void GetRevenueData()
        {
            RevenueSummary.Clear();
            TotalRevenue = 0;
            TotalDeposits = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    #region Revenue by Reservation
                    command.CommandText = @"SELECT CheckInDate, CheckOutDate
                                            FROM Reservations
                                            WHERE CheckInDate BETWEEN @fromDate AND @toDate";
                    command.Parameters.AddWithValue("@fromDate", startDate);
                    command.Parameters.AddWithValue("@toDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime checkIn = (DateTime)reader["CheckInDate"];
                            DateTime checkOut = (DateTime)reader["CheckOutDate"];

                            for (var date = checkIn; date < checkOut; date = date.AddDays(1))
                            {
                                decimal rate = GetRoomRate(date);
                                TotalRevenue += rate;
                                TotalDeposits += (rate * 0.10m); 

                                var existing = RevenueSummary.FirstOrDefault(r => r.Date == date.ToString("dd MMM"));
                                if (existing.Date != null)
                                {
                                    RevenueSummary.Remove(existing);
                                    RevenueSummary.Add(new RevenueByDate
                                    {
                                        Date = existing.Date,
                                        TotalAmount = existing.TotalAmount + rate
                                    });
                                }
                                else
                                {
                                    RevenueSummary.Add(new RevenueByDate
                                    {
                                        Date = date.ToString("dd MMM"),
                                        TotalAmount = rate
                                    });
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private decimal GetRoomRate(DateTime date)
        {
            #region Seasonal Room Rates
            if (date.Month == 12)
            {
                if (date.Day >= 1 && date.Day <= 7)
                    return 550; // Low Season
                else if (date.Day >= 8 && date.Day <= 15)
                    return 750; // Mid Season
                else
                    return 995; // high Season
            }
            return 550; // after/before dec
            #endregion
        }
        #endregion

        #region Public Methods
        public bool LoadReport(DateTime fromDate, DateTime toDate)
        {
            endDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, toDate.Hour, toDate.Minute, 59);
            if (fromDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = fromDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetSummaryData();
                GetRevenueData();
                return true;
            }
            return false;
        }
        #endregion
    }

    #region Supporting Structure
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    #endregion
}
