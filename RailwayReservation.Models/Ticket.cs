using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string TicketNumber { get; set; }

        public int DepartureStationId { get; set; }

        public int ArrivalStationId { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DiscountPercantage? DiscountPercentage { get; set; }

        public int PlaceNumber { get; set; }

        public int TrainNumberId { get; set; }

        public int VagonNumber { get; set; }

        public int PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Train TrainNumber { get; set; }
        public virtual City DepartureStation { get; set; }
        public virtual City ArrivalStation { get; set; }
    }
}
