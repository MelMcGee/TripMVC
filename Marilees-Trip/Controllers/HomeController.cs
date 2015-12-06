using System.Web.Mvc;
using Marilees_Trip.Models;
using System.Diagnostics;

namespace Marilees_Trip.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PostToFlights(QPX.QPXModel data)
        {
            // test here
            Debug.Assert(data != null);
            QPX flights = new QPX();

            //TODO: Enter Your key from google in the appid string, below.
            string appid = "AIzaSyCVqTFz2c9UytYbGfz-WTq5pYp4caGAgw0";
            //enter your appid here
            string url = "https://www.googleapis.com/qpxExpress/v1/trips/search?key=" + appid;
            return Json(flights.PostToFlights(url, data));
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