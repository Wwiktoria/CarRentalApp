using CarRentalApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.ViewModels
{
    public class CarsViewModel
    {
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
    }
   
}