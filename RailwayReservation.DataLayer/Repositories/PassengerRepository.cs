using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataLayer.DomainEntities;
using RailwayReservation.Models;
using System.Data.Entity;

namespace RailwayReservation.DataLayer.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger>
    {
        public PassengerRepository(DbContext context) : base(context)
        {
        }

        public Passenger GetSingle(int passengerId) 
        {
            var query = GetAll().FirstOrDefault(p => p.PassengerID == passengerId);
            return query;
        }
    }
}
