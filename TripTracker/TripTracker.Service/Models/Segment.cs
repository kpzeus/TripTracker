using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.Service.Models
{
    public class Segment
    {
        public int Id { get; set; }

        public int TripId { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
