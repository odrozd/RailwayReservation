using RailwayReservation.DataLayer;
using RailwayReservation.DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RailwayReservationContext, Configuration>());
        }
    }
}
