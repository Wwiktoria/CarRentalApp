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
        [RegularExpression(@"^[A-Z]{2,3}-\d{4}$", ErrorMessage = "Invalid car registration number.")]
        public string CarRegistrationNumberNotKey { get; set; }

        [Required]
        [Display(Name = "Year of production")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid year format.")]
        public String CarYearOfProduction { get; set; }

        [Required]
        [Display(Name = "Car mileage")]
        
        public string CarMileage { get; set; }

        [Display(Name = "Is rented")]
        public bool CarIsRented { get; set; }
        public int CarModelId { get; set; }

        [Required]
        [Display(Name = "Car renatal cost per hour")]
        public string CarRentalCost { get; set; }

        [Required]
        [Display(Name = "Car power")]
        public string CarPower { get; set; }

        [Required]
        [Display(Name = "Car color")]
        public string CarColor { get; set; }

        [Required]
        [Display(Name = "Number of seats")]
        public string CarNumberOfSeats { get; set; }

        [Required]
        [Display(Name = "Body Type")]
        public EnumCarBody CarBodyType { get; set; }
    }
   
}