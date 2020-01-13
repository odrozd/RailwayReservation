using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public int DepartureStationId { get; set; }

        public int ArrivalStationId { get; set; }

        public int DepartureFrequecnyId { get; set; }

        public TimeSpan? DepartureTime { get; set; }

        public TimeSpan? TravelTime { get; set; }

        public int TrainId { get; set; }

        public virtual City DepartureStation { get; set; }
        public virtual City ArrivalStation { get; set; }
        public virtual Train Train { get; set; }
        public virtual DepartureFrequency DepartureFrequency { get; set; }

    }
}
