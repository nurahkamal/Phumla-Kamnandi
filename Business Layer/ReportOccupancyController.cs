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
        private ReportOccupancyDB _dbController;

        public ReportOccupancyController()
        {
            _dbController = new ReportOccupancyDB();
        }

        public DataTable GetRoomsBySeason(DateTime startDate, DateTime endDate)
        {
            return _dbController.GetGuestsByRoomType(startDate, endDate);
        }

        public DataTable GetRoomsOccupiedByDay(DateTime startDate, DateTime endDate)
        {
            return _dbController.GetRoomsOccupiedByDay(startDate, endDate);
        }

        public DataTable GetDailyDeposits(DateTime startDate, DateTime endDate)
        {
            return _dbController.GetDailyDepositCount(startDate, endDate);
        }

        public decimal GetTotalDeposits(DateTime startDate, DateTime endDate)
        {
            return _dbController.GetTotalDeposits(startDate, endDate);
        }

        public DataTable GetRoomOccupancyForGantt(DateTime startDate, DateTime endDate)
        {
            return _dbController.GetRoomOccupancyForGantt(startDate, endDate);
        }
    }
}
