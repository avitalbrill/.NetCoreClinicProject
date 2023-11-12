using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private static List<Doctor> doctors = new List<Doctor> { new Doctor { tz = 325997633, firstName="avital",lastName="brill" ,domain="dentist"} };

        public DoctorController() 
        {
          
        }   
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return doctors;
        }
        // GET: api/<EventsController>/{tz}
        [HttpGet]
        public ActionResult<Doctor> Get(int tz)
        {
            Doctor d = doctors.Find(e => e.tz == tz);
                if (d != null)
                return d;
                else return NotFound();
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Doctor newDoctor)
        {
            doctors.Add(new Doctor { tz=newDoctor.tz,firstName=newDoctor.firstName,lastName=newDoctor.lastName,domain=newDoctor.domain });
        }

        // PUT api/<EventsController>/{tz}
        [HttpPut("{id}")]
        public void Put(int tz,Doctor d)
        {
            Doctor d1 = doctors.Find(e => e.tz == tz);
            d1.tz=d.tz;  
            d1.firstName=d.firstName;
            d1.lastName=d.lastName;
            d1.domain=d.domain;   
        }

        // DELETE api/<EventsController>/{tz}
        [HttpDelete("{id}")]
        public void Delete(int tz)
        {
            Doctor d = doctors.Find(e => e.tz == tz);
            doctors.Remove(d);
        }
    }
}
