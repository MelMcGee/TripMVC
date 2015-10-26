using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marilees_Trip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string fromCity, string toCity, string departDate, string returnDate)
        {
            ViewBag.Message = "to " + toCity;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Trip Switch";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Trip Switch";

            return View();
        }
    }
}