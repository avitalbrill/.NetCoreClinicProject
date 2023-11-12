using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PatientController : Controller
    {
        private static List<Patient> patients = new List<Patient> { new Patient { tz = 325997633, firstName = "avital", lastName = "brill", age = 19 } };

        public PatientController()
        {

        }
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return patients;
        }
        // GET: api/<EventsController>/{tz}
        [HttpGet]
        public ActionResult<Patient> Get(int tz)
        {
            Patient p = patients.Find(e => e.tz == tz);
            if (p != null)
                return p;
             return NotFound();
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Patient newPatient)
        {
            patients.Add(new Patient { tz = newPatient.tz, firstName = newPatient.firstName, lastName = newPatient.lastName, age = newPatient.age });
        }

        // PUT api/<EventsController>/{tz}
        [HttpPut("{id}")]
        public void Put(int tz, Patient p)
        {
            Patient p1 = patients.Find(e => e.tz == tz);
            p1.tz = p.tz;
            p1.firstName = p.firstName;
            p1.lastName = p.lastName;
            p1.age = p.age;
        }

        // DELETE api/<EventsController>/{tz}
        [HttpDelete("{id}")]
        public void Delete(int tz)
        {
            Patient p1 = patients.Find(e => e.tz == tz);
            patients.Remove(p1);
        }
    }
}
