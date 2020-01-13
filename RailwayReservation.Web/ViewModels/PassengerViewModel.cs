using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Web.ViewModels
{
    public class PassengerViewModel
    {
        public int PassengerId { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        public string LastName { get; set; }
    }
}