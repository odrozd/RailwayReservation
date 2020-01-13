//using DataLayer.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayReservation.Models;

namespace RailwayReservation.Web.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SelectedDepartureStationId { get;set; }
        public int SelectedArrivalStationId { get; set; }

        public SelectList CitiesList {get; set;}
    }
}