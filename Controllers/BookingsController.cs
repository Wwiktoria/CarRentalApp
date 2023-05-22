using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRentalApp.Models;
using CarRentalApp.Models.DbModels;
using CarRentalApp.Models.ViewModels;

namespace CarRentalApp.Controllers
{
    public class BookingsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Car).Include(b => b.Client);
            return View(bookings.ToList());
        }

        // GET: Bookings/Search?phoneNumber=123456789
        public ActionResult Search(string phoneNumber)
        {
            var bookings = db.Bookings.Where(b => b.Client.ClientTelephone == phoneNumber)
                                      .Include(b => b.Car)
                                      .Include(b => b.Client);
            return View("Searched", bookings.ToList());
        }

        

        //public ActionResult Rent()
        //{
        //    //ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName");
        //    //ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName");
        //    //ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName");
        //    //Booking booking = new Booking();
        //    //booking.BookingToRental(booking);
        //    //return View("../Rentals/Create");
        //}

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName");
            return View(new BookingsViewModel());
        }

        // POST: Bookings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingDate,BookingStartDate,BookingEndDate,BookingCost,ClientId,CarRegistrationNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", booking.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", booking.ClientId);
            return View(new Booking());
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", booking.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", booking.ClientId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingDate,BookingStartDate,BookingEndDate,BookingCost,ClientId,CarRegistrationNumber")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", booking.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", booking.ClientId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
