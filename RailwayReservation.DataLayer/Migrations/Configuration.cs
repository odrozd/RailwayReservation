using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using RailwayReservation.Models;
using RailwayReservation.Models.Enums;

namespace RailwayReservation.DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.RailwayReservationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DataLayer.RailwayReservationContext";
        }

#if true
        protected override void Seed(DataLayer.RailwayReservationContext context)
        {
            var cities = new List<City>{
                    new City {Name = "Vinnicya"},
                    new City {Name = "Dnipropetrovsk"},
                    new City {Name = "Donetsk"},
                    new City {Name = "Zhitomyr"},
                    new City {Name = "Zaporizhya"},
                    new City {Name = "Ivano-Frankovsk"},
                    new City {Name = "Kyiv"},
                    new City {Name = "Kirovograd"},
                    new City {Name = "Lugansk"},
                    new City {Name = "Lutsk"},
                    new City {Name = "Lviv"},
                    new City {Name = "Mykolaiv"},
                    new City {Name = "Odessa"},
                    new City {Name = "Poltava"},
                    new City {Name = "Rivne"},
                    new City {Name = "Simferopol"},
                    new City {Name = "Sumy"},
                    new City {Name = "Ternopil"},
                    new City {Name = "Uzhgorod"},
                    new City {Name = "Kharkiv"},
                    new City {Name = "Kherson"},
                    new City {Name = "Khmelnytskiy"},
                    new City {Name = "Cherkasy"},
                    new City {Name = "Chernigov"},
                    new City {Name = "Chernivci"}
            };

            context.Cities.AddOrUpdate(c => new { c.Name }, cities.ToArray());

            var departureFrequencyList = new List<DepartureFrequency>(){
                new DepartureFrequency { DepartureFrequencyType = Frequency.EveryDay },
                new DepartureFrequency { DepartureFrequencyType = Frequency.EvenDay },
                new DepartureFrequency { DepartureFrequencyType = Frequency.OddDay }
            };
            context.DepartureFrequency.AddOrUpdate(d => new { d.DepartureFrequencyType }, departureFrequencyList.ToArray());

            var trainsList = new List<Train>()
            {
               new Train { TrainNumber = "41P", TraintType = TrainType.Regular },
               new Train { TrainNumber = "141", TraintType = TrainType.Regular },
               new Train { TrainNumber = "169", TraintType = TrainType.Express },
               new Train { TrainNumber = "91", TraintType = TrainType.Regular }
            };

            var scheduleTable = new List<Schedule>()
            {
                new Schedule
                {
                    DepartureStation = cities.Where(c => c.Name == "Dnipropetrovsk").FirstOrDefault(),
                    ArrivalStation = cities.Where(c => c.Name == "Lviv").FirstOrDefault(),
                    DepartureFrequency = departureFrequencyList.Where(d => d.DepartureFrequencyType == Frequency.EveryDay).FirstOrDefault(),
                    DepartureTime = new TimeSpan(11, 15, 00),
                    TravelTime = new TimeSpan(18, 45, 00),
                    Train = trainsList.Where(t => t.TrainNumber == "41P").FirstOrDefault() 
                },

                new Schedule
                {
                    DepartureStation = cities.Where(c => c.Name == "Kyiv").FirstOrDefault(),
                    ArrivalStation = cities.Where(c => c.Name == "Lviv").FirstOrDefault(),
                    DepartureFrequency = departureFrequencyList.Where(d => d.DepartureFrequencyType == Frequency.EveryDay).FirstOrDefault(),
                    DepartureTime = new TimeSpan(15, 52, 00),
                    TravelTime = new TimeSpan(12, 45, 00),
                    Train = trainsList.Where(t => t.TrainNumber == "141").FirstOrDefault()
                },

                new Schedule
                {
                    DepartureStation = cities.Where(c => c.Name == "Kyiv").FirstOrDefault(),
                    ArrivalStation = cities.Where(c => c.Name == "Lviv").FirstOrDefault(),
                    DepartureFrequency = departureFrequencyList.Where(d => d.DepartureFrequencyType == Frequency.EveryDay).FirstOrDefault(),
                    DepartureTime = new TimeSpan(17, 26, 00),
                    TravelTime = new TimeSpan(4, 54, 00),
                    Train = trainsList.Where(t => t.TrainNumber == "169").FirstOrDefault()
                },

                new Schedule
                {
                    DepartureStation = cities.Where(c => c.Name == "Kyiv").FirstOrDefault(),
                    ArrivalStation = cities.Where(c => c.Name == "Lviv").FirstOrDefault(),
                    DepartureFrequency = departureFrequencyList.Where(d => d.DepartureFrequencyType == Frequency.EveryDay).FirstOrDefault(),
                    DepartureTime = new TimeSpan(22, 40, 00),
                    TravelTime = new TimeSpan(7, 46, 00),
                    Train = trainsList.Where(t => t.TrainNumber == "91").FirstOrDefault()
                }
            };  

            context.Schedule.AddOrUpdate(scheduleTable.ToArray());
        }
#endif
    }
}
