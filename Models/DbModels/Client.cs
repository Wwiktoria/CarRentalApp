using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace CarRentalApp.Models.DbModels
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }


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
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Enter phone number in format xxx-xxx-xxx.")]
        public string ClientTelephone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailUnique", controller: "Client", AdditionalFields = "Id")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Enter email address in format mail@example.com")]
        public string ClientEmail { get; set; }

        [Required]
        [Display(Name = "Street")]
        [RegularExpression(@"\b[A-Z].*?\b", ErrorMessage = "Enter street from capital letter (Streetexample)")]

        public string ClientStreet { get; set; }

        [Required]
        [Display(Name = "Building Number")]
        [RegularExpression(@"[0-9][a-z]", ErrorMessage = "Enter building number in correct way (number + letter[otpional])")]

        public string ClientBuildingNumber { get; set; }

        [Required]
        [Display(Name = "Flat Number")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Enter buildin number in correct way")]
        public string ClientFlatNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        [RegularExpression(@"^([a-zA-Z\u0080-\u024F]+(?:. |-| |'))*[a-zA-Z\u0080-\u024F]*$", ErrorMessage = "Enter correct city name")]
        public string ClientCity { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Rental> Rentals { get; set; }



        

        public Client() { }

        public Client(string clientName, string clientSurname, IdentityDocument clientDocumentName, string clientDocumentId, string clientTelephone, string clientEmail, string clientStreet, string clientBuildingNumber, string clientFlatNumber, string clientCity)
        {

            ClientName = clientName;
            ClientSurname = clientSurname;
            ClientDocumentId = clientDocumentId;
            ClientDocumentName = clientDocumentName;
            ClientTelephone = clientTelephone;
            ClientEmail = clientEmail;
            ClientStreet = clientStreet;
            ClientBuildingNumber = clientBuildingNumber;
            ClientFlatNumber = clientFlatNumber;
            ClientCity = clientCity;
        }

        public string ClientFullName
        {
            get { return string.Format("{0} {1}", ClientName, ClientSurname); }
        }

    }
    public enum IdentityDocument
    {
        [Description("Passport")]
        Passport,

        [Description("National Id Card")]
        National_Id_Card,

        [Description("Driver's license")]
        Driver_s_license,

        [Description("Birth Certificate")]
        Birth_Certificate,

        [Description("Social Security Card")]
        Social_Security_Card,

        [Description("Military Id")]
        Military_Id,

        [Description(" Resident Permit")]
        Resident_Permit
    }
}
