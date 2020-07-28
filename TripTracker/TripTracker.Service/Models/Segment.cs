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

        public string Descripton { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }
    }
}
