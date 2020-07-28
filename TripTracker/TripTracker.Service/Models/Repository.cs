using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.Service.Models
{
    public class Repository
    {
        public List<Trip> MyTrips = new List<Trip>();

        public Repository()
        {
            MyTrips.Add(new Trip() 
            { 
                Id= 1,
                Name = "KP Trip",
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(3)
            });
        }
    }
}
