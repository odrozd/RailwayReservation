using RailwayReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Models
{
    public class DepartureFrequency
    {
        public int DepartureFrequencyId { get; set; }

        public Frequency DepartureFrequencyType { get; set; } 
    } 
}
