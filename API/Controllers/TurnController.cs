using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    public class TurnController : Controller
    {
       public readonly DataContext _dataContext;    
        public TurnController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Turn> Get()
        {
            return _dataContext.Turns;
        }
        // GET: api/<EventsController>/{hour}
        [HttpGet]
        public ActionResult<Turn> Get(int hour)
        {
            if (hour>24)
                return NotFound();
            Turn t = _dataContext.Turns.Find(e => e.Hour == hour);
            if (t is null)
                return NotFound();
            return t;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Turn newTurn)
        {
            _dataContext.Turns.Add(new Turn { Date=newTurn.Date,Hour=newTurn.Hour,TreatmentDuration=newTurn.TreatmentDuration });
        }

        // PUT api/<EventsController>/{hour}
        [HttpPut("{id}")]
        public IActionResult Put(int hour,[FromBody] Turn t)
        {
            if (t is null)
                return NotFound();
            Turn t1 = _dataContext.Turns.Find(e => e.Hour == hour);
            if (t1 == null)
                return BadRequest();
            t1.Date = t.Date;
            t1.Hour = t.Hour;
            t1.TreatmentDuration = t.TreatmentDuration;
            return NoContent();
        }

        // DELETE api/<EventsController>/{hour}
        [HttpDelete("{id}")]
        public IActionResult Delete(DateTime date)
        {
            Turn t= _dataContext.Turns.Find(e => e.Date == date);
            if (date==null)
                return NotFound();
            _dataContext.Turns.Remove(t);
            return NoContent();
        }
    }
}
