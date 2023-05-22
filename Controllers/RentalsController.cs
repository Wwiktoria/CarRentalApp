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
    public class RentalsController : Controller
    {
        public DatabaseContext db = new DatabaseContext();
        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Car).Include(r => r.Client).Include(r => r.Worker);
            return View(rentals.ToList());
        }

        public ActionResult RentalCost()
        {
            var lastRental = db.Rentals.OrderByDescending(r => r.RentalId).FirstOrDefault();
            if (lastRental != null)
            {
                ViewBag.RentalCost = lastRental.RentalCost;
            }
            return View();
        }

        


        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        { 

            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName");
            
            return View(new RentalsViewModel());
            
        }
        
        public ActionResult CreateFromBooking(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }

            var rental = new Rental
            {
                RentalStartDate = booking.BookingStartDate,
                RentalEndDate = booking.BookingEndDate,
                ClientId = booking.ClientId,
                CarRegistrationNumber = booking.CarRegistrationNumber
            };

            ViewBag.RentalStartDate = booking.BookingStartDate;
            ViewBag.RentalEndDate = rental.RentalEndDate;
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", rental.ClientId);
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", rental.CarRegistrationNumber);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName");


            
            return View(new Rental());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromBooking([Bind(Include = "RentalId,RentalCost,RentalStartDate,RentalEndDate,ClientId,WorkerId,CarRegistrationNumber")] Rental rental, int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                rental.CalculateRentalCost();
                db.Rentals.Add(rental);
                db.Bookings.Remove(booking);

                //Car car = db.Cars.Find(booking.CarRegistrationNumber);

                //if (car != null)
                //{
                //    // Ustawienie statusu samochodu na wynajęty
                //    car.CarIsRented = true;
                //}
                db.SaveChanges();
                return RedirectToAction("RentalCost");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "FullCarName", rental.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", rental.ClientId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName", rental.WorkerId);

            return View(new Rental());
        }

        // POST: Rentals/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalCost,RentalStartDate,RentalEndDate,ClientId,WorkerId,CarRegistrationNumber")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                
                rental.CalculateRentalCost();
                //ViewBag.RentalCost = rental.RentalCost;
                
                //Car car = db.Cars.Find(rental.CarRegistrationNumber);

                //if (car != null)
                //{
                //    // Ustawienie statusu samochodu na wynajęty
                //    car.CarIsRented = true;
                //}
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("RentalCost");
            }

            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", rental.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", rental.ClientId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName", rental.WorkerId);
            return View(new Rental());
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", rental.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", rental.ClientId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName", rental.WorkerId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalCost,RentalStartDate,RentalEndDate,ClientId,WorkerId,CarRegistrationNumber")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarRegistrationNumber = new SelectList(db.Cars, "CarRegistrationNumber", "FullCarName", rental.CarRegistrationNumber);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientFullName", rental.ClientId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "FullWorkerName", rental.WorkerId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
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
