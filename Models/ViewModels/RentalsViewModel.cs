using CarRentalApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.ViewModels
{
    public class RentalsViewModel
    {
        [Required]
        [Display(Name = "Rental Start Date")]
        [DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; }

        [Required]
        [Display(Name = "Rental End Date")]
        [DataType(DataType.Date)]
        public DateTime RentalEndDate { get; set; }


        [Required]
        public int ClientId { get; set; }

        
        [Required]
        public int WorkerId { get; set; }

        public int CarRegistrationNumber { get; set; }
        public bool ShowNotification { get; set; }
        public string NotificationMessage { get; set; }
    }
}