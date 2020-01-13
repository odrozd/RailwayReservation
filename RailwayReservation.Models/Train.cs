using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }

        public string TrainNumber { get; set; }

        public TrainType TraintType { get; set; }
    }
}
