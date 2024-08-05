using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.Entities;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> Get()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            if (doctors == null)
                return NotFound();
            return Ok(doctorsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> Get(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();

            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Post([FromBody] DoctorPostModel newDoctor)
        {
            var doctorToAdd = new Doctor
            {
                Tz = newDoctor.Tz ?? 1234,
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Domain = newDoctor.Domain
            };

            var newD = await _doctorService.AddDoctorAsync(doctorToAdd);
            var doctorDto = _mapper.Map<DoctorDto>(newD);

            return Ok(doctorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorDto>> Put(int id, [FromBody] DoctorPostModel d)
        {
            var doctorToUpdate = new Doctor
            {
                Tz = d.Tz ?? 1234,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Domain = d.Domain
            };

            var updatedDoctor = await _doctorService.UpdateDoctorAsync(id, doctorToUpdate);
            if (updatedDoctor == null)
                return NotFound();

            var doctorDto = _mapper.Map<DoctorDto>(updatedDoctor);
            return Ok(doctorDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}

