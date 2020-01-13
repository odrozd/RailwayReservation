using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservation.Web.Controllers
{
    public class PassController : Controller
    {
        //
        // GET: /Pass/

        public ActionResult Search(string name)
        {
            return Content(name);
        }

    }
}
