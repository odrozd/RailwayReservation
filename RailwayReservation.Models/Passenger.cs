using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Models
{
    public class Passenger
    {
        public Passenger()
        {
            Tickets = new List<Ticket>();
        }

        public int PassengerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
