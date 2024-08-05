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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> Get()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            var patientsDto = _mapper.Map<IEnumerable<PatientDto>>(patients);
            if (patients == null)
                return NotFound();
            return Ok(patientsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> Get(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            var patientDto = _mapper.Map<PatientDto>(patient);
            return Ok(patientDto);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> Post([FromBody] PatientPostModel newPatient)
        {
            var patientToAdd = new Patient
            {
                Tz = newPatient.Tz,
                FirstName = newPatient.FirstName,
                LastName = newPatient.LastName,
                Age = newPatient.Age
            };

            var newP = await _patientService.AddPatientAsync(patientToAdd);
            var patientDto = _mapper.Map<PatientDto>(newP);

            return Ok(patientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDto>> Put(int id, [FromBody] PatientPostModel p)
        {
            var patientToUpdate = new Patient
            {
                Tz = p.Tz,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age
            };

            var updatedPatient = await _patientService.UpdatePatientAsync(id, patientToUpdate);
            if (updatedPatient == null)
                return NotFound();

            var patientDto = _mapper.Map<PatientDto>(updatedPatient);
            return Ok(patientDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}

