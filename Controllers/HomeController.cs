using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
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
            var item = new MenuItem { Link = "/Manage/Index", LinkName = "Админ" };
            list.Add(item);

            if (User.Identity.IsAuthenticated)
            {
                list.Add(new MenuItem { Link = "/Manage/Index", LinkName = "Админ" });
                list.Remove(item);
            }
            return PartialView("SideMenu", list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.countries = db.Countries.Select(s => s.Name).ToArray();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTourModel createTourModel, IEnumerable<HttpPostedFileBase> uploads)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in uploads)
                {
                    if (file != null)
                    {
                        // получаем имя файла
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        // сохраняем файл в папку Files в проекте
                        file.SaveAs(Server.MapPath("~/images/" + fileName));
                        Picture picture = new Picture() { Url = fileName };
                        db.Pictures.Add(picture);//хз зачем
                        createTourModel.Tour.Pictures.Add(picture);
                    }
                }

                db.Countries.FirstOrDefault(c => c.Name == createTourModel.Country).Tours.Add(createTourModel.Tour);
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            ViewBag.countries = db.Countries.Select(s => s.Name).ToArray();
            return View(createTourModel);

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