using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.DbModels
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }

        [Required]
        [Display(Name = "Car brand")]
        public string CarBrandName { get; set; }

        [Required]
        [Display(Name = "Car model")]
        public string CarModelName { get; set; }

        public virtual List<Car> Cars { get; set; }


        public CarModel()
        {
            CarModelId++;
        }

        public CarModel(string carBrandName, string carModelName)
        {
            CarBrandName = carBrandName;
            CarModelName = carModelName;
        }

        public string FullCarModel
        {
            get { return string.Format("{0} - {1}", CarBrandName, CarModelName); }

        }
    }
}