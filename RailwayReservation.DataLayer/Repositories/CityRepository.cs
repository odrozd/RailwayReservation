//using DataLayer.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservation.Models;
using System.Data.Entity;

namespace RailwayReservation.DataLayer.Repositories
{
    public class CityRepository : GenericRepository<City>
    {
        public CityRepository(DbContext context)
            : base(context)
        {}

        public City GetCityById(int cityId)
        {
            var query = GetAll().FirstOrDefault(c => c.CityId == cityId);
            return query;
        }

        public City GetCityByName(string cityName)
        {
            var city = GetAll().FirstOrDefault(c => c.Name == cityName);
            return city;
        }
    }
}
