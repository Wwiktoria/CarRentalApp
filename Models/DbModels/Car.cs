using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.DbModels
{
    public class Car
    {
        [Key]
        public int CarRegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [RegularExpression(@"^[A-Z|0-9]{5,7}$", ErrorMessage = "Enter correct registration number (use only uppercase letters and numbers)")]
        public string CarRegistrationNumberNotKey { get; set; }

        [Required]
        [Display(Name = "Year of production")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Enter correct year (between 1900 and 2099)")]
        public String CarYearOfProduction { get; set; }

        [Required]
        [Display(Name = "Car mileage")]
        [RegularExpression(@"[1-9]+[0-9]*", ErrorMessage = "Enter correct mileage (don't start with \"0\" )")]
        public string CarMileage { get; set; }

        [Display(Name = "Is rented")]
        public bool CarIsRented { get; set; }
        public int CarModelId { get; set; }

        [Required]
        [Display(Name = "Car renatal cost per hour")]
        [RegularExpression(@"[1-9]+[0-9]*", ErrorMessage = "Enter correct cost (don't start with \"0\" )")]
        public string CarRentalCost { get; set; }

        [Required]
        [Display(Name = "Car power")]
        [RegularExpression(@"[1-9]+[0-9]*", ErrorMessage = "Enter correct power (don't start with \"0\" )")]
        public string CarPower { get; set; }

        [Required]
        [Display(Name = "Car color")]
        public string CarColor { get; set; }

        [Required]
        [Display(Name = "Number of seats")]
        [RegularExpression(@"[1-9]+[0-9]*", ErrorMessage = "Enter correct number of seats (don't start with \"0\" )")]
        public string CarNumberOfSeats { get; set; }

        [Required]
        [Display(Name = "Body Type")]
        public EnumCarBody CarBodyType { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual List<Rental> Rentals { get; set; }
        public virtual List<Booking> Bookings { get; set; }

        public Car()
        {
            CarRegistrationNumber++;
            CarIsRented = false;
        }


        public Car(string carRegistrationNumberNotKey, string carYearOfProduction, string carMileage, CarModel carModel, string carRentalCost, string carPower, string carColor, string carNumberOfSeats, EnumCarBody carBodyType)
        {
            CarRegistrationNumberNotKey = carRegistrationNumberNotKey;
            CarYearOfProduction = carYearOfProduction;
            CarMileage = carMileage;
            CarModel = carModel;
            CarRentalCost = carRentalCost;
            CarPower = carPower;
            CarColor = carColor;
            CarNumberOfSeats = carNumberOfSeats;
            CarBodyType = carBodyType;
            CarModelId = carModel.CarModelId;
        }

        public string FullCarName
        {
            get { return string.Format("{0}, {1}", CarRegistrationNumberNotKey, CarModel.FullCarModel); }
        }
        


    }

    
    public enum EnumCarBody { Sedan, Hatchback, SUV, MPV, Coupe, Convertible, Pickup, Van, Compact }
}