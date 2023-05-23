using CarRentalApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.DbModels
{
    public class Rental
    {
        DatabaseContext db = new DatabaseContext();
        [Key]
        public int RentalId { get; set; }

        [Required]
        [Display(Name = "Rental Cost")]
        public int RentalCost { get; set; }
        

        [Required]
        [Display(Name = "Rental Start Date")]
        [DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; }

        [Required]
        [Display(Name = "Rental End Date")]
        [DataType(DataType.Date)]
        public DateTime RentalEndDate { get; set; }

        public bool ShowNotification { get; set; }
        public string NotificationMessage { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        [Required]
        public int WorkerId { get; set; }
        
       
        public virtual Worker Worker { get; set; }
        [Required]
        public int CarRegistrationNumber { get; set; }

        public virtual Car Car { get; set; }

        public List<Rental> Reservations { get; set; }

        public Rental()
        {
            RentalId++;
        }

        public Rental(DateTime rentalStartDate, DateTime rentalEndDate, Client client, Worker worker, Car car)
        {
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
            Client = client;
            Worker = worker;
            Car = car;
            CarRegistrationNumber = car.CarRegistrationNumber;
            ClientId = client.ClientId;
            WorkerId = worker.WorkerId;
        }

        public void CalculateRentalCost()
        {
            Car car = db.Cars.Where(x => x.CarRegistrationNumber == CarRegistrationNumber).First();
            double days = (RentalEndDate-RentalStartDate).TotalDays;
            RentalCost = Int32.Parse(car.CarRentalCost) * (int)days;
        }
        
        
    }
}