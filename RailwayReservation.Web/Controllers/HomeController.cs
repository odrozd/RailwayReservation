using RailwayReservation.Models;
using RailwayReservation.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayReservation.Web.ViewModels;
using RailwayReservation.DataLayer;

namespace RailwayReservation.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var model = new CityViewModel();

            IList<CityViewModel> citiesList = new List<CityViewModel>();

            using (var citiesRepository = unitOfWork.Cityrepository)
            {
                foreach (var city in citiesRepository.GetAll())
                {
                    citiesList.Add(new CityViewModel() { Name = city.Name, Id =  city.CityId});
                }
            }
            model.CitiesList = new SelectList(citiesList, "Id", "Name");
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(CityViewModel city)
        {
            return RedirectToAction("Index", "Schedule", city);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
