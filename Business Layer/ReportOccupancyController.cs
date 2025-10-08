using Phumla_Kamnandi.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kamnandi.Business_Layer
{
    public class ReportOccupancyController
    {
        private ReportOccupancyDB _reportDB;

        public ReportOccupancyController()
        {
            _reportDB = new ReportOccupancyDB();
        }

        public DataTable GetDailyOccupancy(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetDailyOccupancy(startDate, endDate);
        }

        public DataTable GetGuestsByRoomType(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetGuestsByRoomType(startDate, endDate);
        }

        public DataTable GetRoomsOccupiedByDay(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetRoomsOccupiedByDay(startDate, endDate);
        }

        public DataTable GetDailyDeposits(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetDailyDepositCount(startDate, endDate);
        }

        public DataTable GetRoomOccupancyForGantt(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetRoomOccupancyForGantt(startDate, endDate);
        }

        public DataTable GetSeasonalRevenue(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetSeasonalRevenue(startDate, endDate);
        }

        public DataTable GetDepositStatus(DateTime startDate, DateTime endDate)
        {
            return _reportDB.GetDepositStatus(startDate, endDate);
        }
    }
}