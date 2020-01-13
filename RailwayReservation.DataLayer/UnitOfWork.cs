using RailwayReservation.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataLayer
{
    public class UnitOfWork :IDisposable
    {
        private RailwayReservationContext context = new RailwayReservationContext();
        private SchdeuleRepository scheduleRepository;
        private CityRepository cityRepository;
        private PassengerRepository passengerRepository;
        private bool disposed = false;

        public SchdeuleRepository SchdeuleRepository
        {
            get 
            {
                if (this.scheduleRepository == null)
                {
                    this.scheduleRepository = new SchdeuleRepository(context);
                }
                return scheduleRepository;
            }
        }

        public CityRepository Cityrepository
        {
            get
            {
                if (cityRepository == null)
                {
                    cityRepository = new CityRepository(context);
                }
                return cityRepository;
            }
        }

        public PassengerRepository PassengerRepositry
        {
            get
            {
                if (passengerRepository == null)
                {
                    passengerRepository = new PassengerRepository(context);
                }
                return passengerRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
