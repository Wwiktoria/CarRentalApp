using CarRentalApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarRentalApp.Models.ViewModels
{
    public class BookingsViewModel
    {
        [Display(Name = "Booking Start Date")]
        [DataType(DataType.Date)]
        public DateTime BookingStartDate { get; set; }

        [Display(Name = "Booking Start Date")]
        [DataType(DataType.Date)]
        public DateTime BookingEndDate { get; set; }
        public Client ClientId { get; set; }
        public Car CarRegistrationNumber { get; set; }
    }

}