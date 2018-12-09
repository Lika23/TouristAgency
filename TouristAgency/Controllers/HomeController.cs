using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class HomeController : Controller
    {
        TourContext db;
        public HomeController()
        {
            db = new TourContext();
        }
        public ActionResult Index()
        {
            IEnumerable<Country> countries = db.Countries.Include("Pictures").ToList();
            CountryListViewModel countriesList = new CountryListViewModel
            {
                Countries = countries.ToList()
            };
            return View(countriesList);
        }
        public ActionResult SideMenu()
        {
            List<MenuItem> list = new List<MenuItem>();
            list.Add(new MenuItem { Link = "/Home/Index", LinkName = "Главная" });
            foreach (var c in db.Countries)
            {
                list.Add(new MenuItem { Link = "/Home/CountryPage/" + c.Id, LinkName = c.Name });

            }
            return PartialView("SideMenu", list);
        }
        [HttpGet]
        public ActionResult TourPage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }


            Tour tour = db.Tours
                .Include("Country")
                .Include("Pictures")
                .FirstOrDefault(t => t.Id == id);
            return View(tour);
        }
        [HttpGet]
        public ActionResult CountryPage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Country country = db.Countries
                .Include("Pictures")
                .Include("Tours")
                .Include("Tours.Pictures")

                .FirstOrDefault(x => x.Id == id);
            return View(country);
        }
        public ActionResult Montenegro()
        {
            IEnumerable<Tour> tours = db.Tours.ToList();
            tours = tours.Where(t => t.Country.Name == "Черногория");
            TourListViewModel toursList = new TourListViewModel
            {
                Tours = tours.ToList()
            };
            return View(toursList);
        }
        public ActionResult Albania()
        {
            return View();
        }
        public ActionResult Croatia()
        {
            return View();
        }
        public ActionResult Italy()
        {
            return View();
        }
        public ActionResult elements()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}