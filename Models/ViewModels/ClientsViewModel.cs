using CarRentalApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CarRentalApp.Models.ViewModels
{
    public class ClientsViewModel
    {
        [Display(Name = "Client Name")]
        [Required]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Client Surname")]
        public string ClientSurname { get; set; }

        [Required]
        [Display(Name = "Document Id")]
        public string ClientDocumentId { get; set; }

        [Required]
        [Display(Name = "Document Name")]
        public IdentityDocument ClientDocumentName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Enter phone number in format xxx-xxx-xxx.")]
        public string ClientTelephone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailUnique", controller: "Client", AdditionalFields = "Id")]
        //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Enter email address in format mail@example.com")]
        public string ClientEmail { get; set; }

        [Required]
        [Display(Name = "Street")]
        //[RegularExpression(@"\b[A-Z].*?\b", ErrorMessage = "Enter street from capital letter (Streetexample)")]

        public string ClientStreet { get; set; }

        [Required]
        [Display(Name = "Building Number")]
        //[RegularExpression(@"[0-9][a-z]", ErrorMessage = "Enter building number in correct way (number + letter[otpional])")]

        public string ClientBuildingNumber { get; set; }

        [Required]
        [Display(Name = "Flat Number")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Enter buildin number in correct way")]
        public string ClientFlatNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        //[RegularExpression(@"^([a-zA-Z\u0080-\u024F]+(?:. |-| |'))*[a-zA-Z\u0080-\u024F]*$", ErrorMessage = "Enter correct city name")]
        public string ClientCity { get; set; }
    }
}