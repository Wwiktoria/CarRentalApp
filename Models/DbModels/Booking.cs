using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.DbModels
{
    public class Booking
    {
        DatabaseContext db = new DatabaseContext();
        [Key]
        public int BookingId { get; set; }

        [Required]
        
        public DateTime BookingDate { get; set; }


        
        public DateTime BookingStartDate { get; set; }


        
        public DateTime BookingEndDate { get; set; }

        [Required]
        [Display(Name = "Booking Cost")]
        public int BookingCost { get; set; }

        [Required]
        public int ClientId { get; set; }


        public virtual Client Client { get; set; }

        [Required]
        public int CarRegistrationNumber { get; set; }


        public virtual Car Car { get; set; }



        public Booking()
        {
            BookingId++;
            BookingDate = DateTime.Today.Date;
        }

        public Booking(DateTime bookingStartDate, DateTime bookingEndDate, int bookingCost, Client client, Car car)
        {
            
            BookingStartDate = bookingStartDate;
            BookingEndDate = bookingEndDate;
            BookingCost = bookingCost;
            Client = client;
            ClientId = client.ClientId;
            Car = car;
            CarRegistrationNumber = car.CarRegistrationNumber;
        }

        public override string ToString()
        {
            return $"{Client.ClientName}, {Client.ClientSurname}, {Car.CarModel}";
        }

        public void BookingToRental(Booking bookingRent)
        {
            Booking booking = db.Bookings.Where(x=>x.BookingId == bookingRent.BookingId).FirstOrDefault();
        }
    }
}
