using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PatientController : Controller
    {
       public readonly DataContext _dataContext;

        public PatientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _dataContext.Patients;
        }
        // GET: api/<EventsController>/{tz}
        [HttpGet]
        public ActionResult<Patient> Get(int tz)
        {
            Patient p = _dataContext.Patients.Find(e => e.Tz == tz);
            if (p != null)
                return p;
             return NotFound();
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Patient newPatient)
        {
            _dataContext.Patients.Add(new Patient { Tz = newPatient.Tz, FirstName = newPatient.FirstName, LastName = newPatient.LastName, Age = newPatient.Age });
        }

        // PUT api/<EventsController>/{tz}
        [HttpPut("{id}")]
        public void Put(int tz, Patient p)
        {
            Patient p1 = _dataContext.Patients.Find(e => e.Tz == tz);
            p1.Tz = p.Tz;
            p1.FirstName = p.FirstName;
            p1.LastName = p.LastName;
            p1.Age = p.Age;
        }

        // DELETE api/<EventsController>/{tz}
        [HttpDelete("{id}")]
        public void Delete(int tz)
        {
            Patient p1 = _dataContext.Patients.Find(e => e.Tz == tz);
            _dataContext.Patients.Remove(p1);
        }
    }
}
