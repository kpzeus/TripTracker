using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripTracker.Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripTracker.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        Repository _repository;

        public TripsController(Repository repository)
        {
            _repository = repository;
        }

        // GET: api/<TripsController>
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.MyTrips;
        }

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _repository.MyTrips.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<TripsController>
        [HttpPost]
        public void Post([FromBody] Trip value)
        {
            _repository.MyTrips.Add(value);
        }

        // PUT api/<TripsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip value)
        {
            this.Delete(value.Id);
            _repository.MyTrips.Add(value);
        }

        // DELETE api/<TripsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.MyTrips.Remove(_repository.MyTrips.First(x => x.Id == id));
        }
    }
}
