using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class SalesReportController
    {
        private SalesReportDB _salesDB;

        public SalesReportController()
        {
            _salesDB = new SalesReportDB();
        }

        public DataTable GetExpectedRevenueTrend(DateTime startDate, DateTime endDate)
        {
            return _salesDB.GetExpectedRevenueTrend(startDate, endDate);
        }

        public DataTable GetSeasonalRevenueData(DateTime startDate, DateTime endDate)
        {
            return _salesDB.GetSeasonalRevenueData(startDate, endDate);
        }

        public DataTable GetDailyRevenueData(DateTime startDate, DateTime endDate)
        {
            return _salesDB.GetDailyRevenueData(startDate, endDate);
        }

        public DataTable GetBookingsByDateData(DateTime startDate, DateTime endDate)
        {
            return _salesDB.GetBookingsByDateData(startDate, endDate);
        }
        public DataTable GetGuestDistributionData(DateTime startDate, DateTime endDate)
        {
            return _salesDB.GetGuestDistributionData(startDate, endDate);
        }
    }
}
