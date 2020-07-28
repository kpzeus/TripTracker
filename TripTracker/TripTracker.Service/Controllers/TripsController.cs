using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker.Service.Data;
using TripTracker.Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TripTracker.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        TripContext _tripContext;

        public TripsController(TripContext tripContext)
        {
            _tripContext = tripContext;
        }

        // GET: api/<TripsController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var t = await _tripContext.Trips.AsNoTracking().ToListAsync();
            return Ok(t);
        }

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _tripContext.Trips.Find(id);
        }

        // POST api/<TripsController>
        [HttpPost]
        public IActionResult Post([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tripContext.Add(value);
            _tripContext.SaveChanges();

            return Ok();
        }

        // PUT api/<TripsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Trip value)
        {
            if (!_tripContext.Trips.Any(x => x.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tripContext.Update(value);
            _tripContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<TripsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var trip = Get(id);

            if (trip == null)
            {
                return NotFound();
            }

            _tripContext.Trips.Remove(trip);
            _tripContext.SaveChanges();

            return Ok();
        }
    }
}
