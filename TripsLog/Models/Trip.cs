using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripsLog.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "Please enter a destination.")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please enter a start date.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter an end date.")]
        public DateTime EndDate { get; set; }
        public string Accommodation { get; set; }
        [Phone(ErrorMessage ="Please enter a valid phone number.")]
        public string AccommodationPhone { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string AccommodationEmail { get; set; }
        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
