using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.ViewModels
{
    public class CarModelsViewModel
    {
        [Required]
        [Display(Name = "Car brand")]
        public string CarBrandName { get; set; }

        [Required]
        [Display(Name = "Car model")]
        public string CarModelName { get; set; }

    }
}