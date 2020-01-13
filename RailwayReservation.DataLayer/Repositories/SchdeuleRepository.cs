using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Models;
using System.Data.Entity;

namespace RailwayReservation.DataLayer.Repositories
{
    public class SchdeuleRepository : GenericRepository<Schedule>
    {
        public SchdeuleRepository(DbContext context)
            : base(context) 
        {
        }

        public Schedule GetSingle(int scheduleId)
        {
            var query = GetAll().FirstOrDefault(s => s.ScheduleID == scheduleId);
            return query;
        }

        public IEnumerable<Schedule> GetAvailbleSchedule(int departureStationId, int arrivalStationId)
        {
            var query = GetAll().Where(s => s.DepartureStationId == departureStationId && s.ArrivalStationId == arrivalStationId).ToList();

            return query;
        }
    }
}
