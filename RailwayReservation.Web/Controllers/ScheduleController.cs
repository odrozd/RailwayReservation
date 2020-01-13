using RailwayReservation.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayReservation.Models;
using RailwayReservation.Web.ViewModels;
using RailwayReservation.DataLayer;

namespace RailwayReservation.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Schedule/

        public ActionResult Index(CityViewModel city)
        {
            var repository = unitOfWork.SchdeuleRepository;

            IList<ScheduleViewModel> availbleSchedules = new List<ScheduleViewModel>();

            foreach (var item in repository.GetAvailbleSchedule(city.SelectedDepartureStationId, city.SelectedArrivalStationId))
            {
                availbleSchedules.Add(new ScheduleViewModel()
                {
                    ScheduleId = item.ScheduleID,
                    DepartureStation = item.DepartureStation.Name,
                    ArrivalStation = item.ArrivalStation.Name,
                    DepartureTime = (item.DepartureTime.Value).ToString(@"hh\:mm"),
                    TravelTime = item.TravelTime.Value.ToString(@"hh\:mm"),
                    ArrivalTime = item.DepartureTime.Value.Add(item.TravelTime.Value).ToString(@"hh\:mm"),
                    TrainNumber = item.Train.TrainNumber,
                    DepartureFrequecnyId = item.DepartureFrequecnyId
                });
            }

            return View(availbleSchedules);
        }

        public ActionResult Details(int? ScheduleId)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
