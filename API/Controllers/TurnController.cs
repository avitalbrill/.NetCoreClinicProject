using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    public class TurnController : Controller
    {
        private static List<Turn> turns = new List<Turn> { new Turn { Date = 09/07/23, hour = 23, treatmentDuration = 10 } };

        public TurnController()
        {

        }
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Turn> Get()
        {
            return turns;
        }
        // GET: api/<EventsController>/{hour}
        [HttpGet]
        public ActionResult<Turn> Get(int hour)
        {
            if (hour>24)
                return NotFound();
            Turn t = turns.Find(e => e.hour == hour);
            if (t is null)
                return NotFound();
            return t;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Turn newTurn)
        {
            turns.Add(new Turn { Date=newTurn.Date,hour=newTurn.hour,treatmentDuration=newTurn.treatmentDuration });
        }

        // PUT api/<EventsController>/{hour}
        [HttpPut("{id}")]
        public IActionResult Put(int hour,[FromBody] Turn t)
        {
            if (t is null)
                return NotFound();
            Turn t1 = turns.Find(e => e.hour == hour);
            if (t1 == null)
                return BadRequest();
            t1.Date = t.Date;
            t1.hour = t.hour;
            t1.treatmentDuration = t.treatmentDuration;
            return NoContent();
        }

        // DELETE api/<EventsController>/{hour}
        [HttpDelete("{id}")]
        public IActionResult Delete(DateTime date)
        {
            Turn t= turns.Find(e => e.Date == date);
            if (date==null)
                return NotFound();
            turns.Remove(t);
            return NoContent();
        }
    }
}
