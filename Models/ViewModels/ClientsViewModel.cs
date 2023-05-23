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
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have at least 3 characters.")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Client Surname")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have at least 3 characters.")]
        public string ClientSurname { get; set; }

        [Required]
        [Display(Name = "Document Id")]
        public string ClientDocumentId { get; set; }

        [Required]
        [Display(Name = "Document Name")]
        public IdentityDocument ClientDocumentName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string ClientTelephone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address.")]
        public string ClientEmail { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string ClientStreet { get; set; }

        [Required]
        [Display(Name = "Building Number")]
        public string ClientBuildingNumber { get; set; }

        
        [Display(Name = "Flat Number")]
        public string ClientFlatNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        public string ClientCity { get; set; }
    }
}