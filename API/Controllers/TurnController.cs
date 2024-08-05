using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solid.API.Entities;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;
using System.Diagnostics.Metrics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private readonly ITurnService _turnService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public TurnController(ITurnService turnService, IDoctorService doctorService, IPatientService patientService, IMapper mapper)
        {
            _turnService = turnService;
            _doctorService = doctorService;
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnDto>>> Get()
        {
            var turns = await _turnService.GetAllTurnsAsync();
            if (turns == null)
                return NotFound();

            var turnsDto = _mapper.Map<IEnumerable<TurnDto>>(turns);
            foreach (var turnDto in turnsDto)
            {
                turnDto.doctorDto = _mapper.Map<DoctorDto>(turns.FirstOrDefault(t => t.Id == turnDto.Id).Doctor);
                turnDto.patientDto = _mapper.Map<PatientDto>(turns.FirstOrDefault(t => t.Id == turnDto.Id).Patient);
            }

            return Ok(turnsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TurnDto>> Get(int id)
        {
            var turn = await _turnService.GetTurnByIdAsync(id);
            if (turn == null)
                return NotFound();

            var turnDto = _mapper.Map<TurnDto>(turn);
            turnDto.doctorDto = _mapper.Map<DoctorDto>(turn.Doctor);
            turnDto.patientDto = _mapper.Map<PatientDto>(turn.Patient);

            return Ok(turnDto);
        }

        [HttpPost]
        public async Task<ActionResult<TurnDto>> Post([FromBody] TurnPostModel newTurn)
        {
            var turnToAdd = new Turn
            {
                Date = newTurn.Date,
                Hour = newTurn.Hour,
                TreatmentDuration = newTurn.TreatmentDuration,
                PatientId = newTurn.PatientId,
                DoctorId = newTurn.DoctorId
            };

            var newT = await _turnService.AddTurnAsync(turnToAdd);

            var turnDto = _mapper.Map<TurnDto>(newT);
            turnDto.doctorDto = _mapper.Map<DoctorDto>(newT.Doctor);
            turnDto.patientDto = _mapper.Map<PatientDto>(newT.Patient);

            return Ok(turnDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TurnDto>> Put(int id, [FromBody] TurnPostModel t)
        {
            var turnToAdd = new Turn
            {
                Date = t.Date,
                Hour = t.Hour,
                TreatmentDuration = t.TreatmentDuration,
                PatientId = t.PatientId,
                DoctorId = t.DoctorId
            };

            var updatedTurn = await _turnService.UpdateTurnAsync(id, turnToAdd);
            if (updatedTurn == null)
                return NotFound();

            var turnDto = _mapper.Map<TurnDto>(updatedTurn);
            turnDto.doctorDto = _mapper.Map<DoctorDto>(updatedTurn.Doctor);
            turnDto.patientDto = _mapper.Map<PatientDto>(updatedTurn.Patient);

            return Ok(turnDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _turnService.DeleteTurnAsync(id);
        }
    }
}
