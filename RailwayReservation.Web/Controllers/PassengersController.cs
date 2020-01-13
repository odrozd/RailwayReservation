using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RailwayReservation.DataLayer.Repositories;
using RailwayReservation.Models;
using RailwayReservation.Web.ViewModels;
using RailwayReservation.DataLayer;

namespace RailwayReservation.Web.Controllers
{
    public class PassengersController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Passengers/

        public ActionResult Index()
        {
            var passengersList = new List<PassengerViewModel>();

            foreach (var passenger in unitOfWork.PassengerRepositry.GetAll().ToList())
            {
                passengersList.Add(new PassengerViewModel
                {
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    PassengerId = passenger.PassengerID
                });
            }
            return View(passengersList);
        }

        public ActionResult Add()
        {
            return this.View(new PassengerViewModel());
        }

        [HttpPost]
        public ActionResult Add(PassengerViewModel passenger)
        {
            var pass = new Passenger()
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName
            };

            unitOfWork.PassengerRepositry.Add(pass);
            unitOfWork.Save();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if(id == -1)
            {
                return this.HttpNotFound();
            }
            var pass = unitOfWork.PassengerRepositry.FindBy(p => p.PassengerID == id).FirstOrDefault();

            var correctPass = new PassengerViewModel()
            {
                FirstName = pass.FirstName,
                LastName = pass.LastName,
                PassengerId = pass.PassengerID
            };

            return View(correctPass);
        }

        [HttpPost]
        public ActionResult Edit(PassengerViewModel passenger)
        {
            var pass = unitOfWork.PassengerRepositry.GetSingle(passenger.PassengerId);
            pass.FirstName = passenger.FirstName;
            pass.LastName = passenger.LastName;

            if (TryUpdateModel(pass))
            {
                unitOfWork.PassengerRepositry.Update(pass);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(passenger.PassengerId);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
