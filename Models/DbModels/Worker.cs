using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models.DbModels
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }

        [Required]
        [Display(Name = "Worker Name")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have at least 3 characters.")]
        public string WorkerName { get; set; }

        [Display(Name = "Worker Surname")]
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have at least 3 characters.")]
        public string WorkerSurname { get; set; }
        public virtual List<Rental> Rentals { get; set; }

        public Worker() { }

        public Worker( string workerName, string workerSurname)
        {
           
            WorkerName = workerName;
            WorkerSurname = workerSurname;
        }

        public string FullWorkerName
        {
            get { return string.Format("{0} {1}", WorkerName, WorkerSurname); }
        }
    }
}