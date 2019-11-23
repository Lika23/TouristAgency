using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TouristAgency.Models;

namespace TouristAgency.Controllers
{
    public class BookTourModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookTourModels
        public ActionResult Index()
        {
            var bookedTours = db.BookedTours.Include(b => b.Tour);
            return View(bookedTours.ToList());
        }

        // GET: BookTourModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookTourModel = db.BookedTours.Find(id);
            if (bookTourModel == null)
            {
                return HttpNotFound();
            }
            return View(bookTourModel);
        }

        // GET: BookTourModels/Create
        public ActionResult Create(int id)
        {
            ViewBag.TourId = id/*new SelectList(db.Tours, "Id", "City")*/;
            return View();
        }

        // POST: BookTourModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TourId,Name,Email,Number")] BookedTour bookTourModel,int id)
        {
            if (ModelState.IsValid)
            {
                bookTourModel.TourId = id;
                db.BookedTours.Add(bookTourModel);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.TourId = new SelectList(db.Tours, "Id", "City", bookTourModel.TourId);
            return View(bookTourModel);
        }

        // GET: BookTourModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookTourModel = db.BookedTours.Find(id);
            if (bookTourModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourId = new SelectList(db.Tours, "Id", "City", bookTourModel.TourId);
            return View(bookTourModel);
        }

        // POST: BookTourModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TourId,Name,Email,Number")] BookedTour bookTourModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTourModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourId = new SelectList(db.Tours, "Id", "City", bookTourModel.TourId);
            return View(bookTourModel);
        }

        // GET: BookTourModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedTour bookTourModel = db.BookedTours.Find(id);
            if (bookTourModel == null)
            {
                return HttpNotFound();
            }
            return View(bookTourModel);
        }

        // POST: BookTourModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookedTour bookTourModel = db.BookedTours.Find(id);
            db.BookedTours.Remove(bookTourModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
