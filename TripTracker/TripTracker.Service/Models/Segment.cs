using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.Service.Models
{
    public class Segment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TripId { get; set; }

        public string Descripton { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }
    }
}
