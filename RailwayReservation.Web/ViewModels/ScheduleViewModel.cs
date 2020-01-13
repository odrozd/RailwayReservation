using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Web.ViewModels
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }

        [Display(Name="Departure Station")]
        public string DepartureStation { get; set; }

        [Display(Name="Arrival Station")]
        public string ArrivalStation { get; set; }

        public int DepartureFrequecnyId { get; set; }

        [Display(Name="Departure Time")]
        public string DepartureTime { get; set; }

        [Display(Name="Arrival Time")]
        public string ArrivalTime { get; set; }

        [Display(Name="Time in Travel")]
        public string TravelTime { get; set; }

        [Display(Name="Train Number")]
        public string TrainNumber { get; set; }
    }
}