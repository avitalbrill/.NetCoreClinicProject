using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public readonly DataContext _dataContext;
        public DoctorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> Get()
        {
            return _dataContext.Doctors;
        }
        // GET: api/<EventsController>/{tz}
        [HttpGet]
        public ActionResult<Doctor> Get(int tz)
        {
            Doctor d = _dataContext.Doctors.Find(e => e.Tz == tz);
            if (d != null)
                return d;
            else return NotFound();
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Doctor newDoctor)
        {
            _dataContext.Doctors.Add(new Doctor { Tz = newDoctor.Tz, FirstName = newDoctor.FirstName, LastName = newDoctor.LastName, Domain = newDoctor.Domain });
        }

        // PUT api/<EventsController>/{tz}
        [HttpPut("{id}")]
        public ActionResult<Doctor> Put(int tz, Doctor d)
        {
            Doctor d1 = _dataContext.Doctors.Find(e => e.Tz == tz);
            if(d1== null)
            {
                return NotFound();
            }
            d1.Tz = d.Tz;
            d1.FirstName = d.FirstName;
            d1.LastName = d.LastName;
            d1.Domain = d.Domain;

            return d1;
        }

        // DELETE api/<EventsController>/{tz}
        [HttpDelete("{id}")]
        public void Delete(int tz)
        {
            Doctor d = _dataContext.Doctors.Find(e => e.Tz == tz);
            _dataContext.Doctors.Remove(d);
        }
    }
}
