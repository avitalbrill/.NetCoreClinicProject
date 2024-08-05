using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data;
using Solid.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
            
        }
        public async Task<Patient> GetPatientByTzAsync(int Tz)
        {
            return await _patientRepository.GetPatientByTzAsync(Tz);
        }
        public async Task<Patient> AddPatientAsync(Patient p)
        {
             return await _patientRepository.AddPatientAsync(p);
        }
        public async Task<Patient> UpdatePatientAsync(int id,Patient pat)
        {
            var p = await _patientRepository.UpdatePatientAsync(id, pat);
            return p;
        }
        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
        }

        public async Task<Patient> GetPatientByIdAsync(int Id)
        {
            return await _patientRepository.GetPatientByIdAsync(Id);
        }
    }
}
