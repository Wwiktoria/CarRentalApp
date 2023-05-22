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
        public string WorkerName { get; set; }

        [Display(Name = "Worker Surname")]
        [Required]
        public string WorkerSurname { get; set; }
        public virtual List<Rental> Rentals { get; set; }

        public Worker() { }

        public Worker(int workerId, string workerName, string workerSurname)
        {
            WorkerId = workerId;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
        }

        public string FullWorkerName
        {
            get { return string.Format("{0} {1}", WorkerName, WorkerSurname); }
        }
    }
}