using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository=doctorRepository;
        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }
        public async Task<Doctor> GetDoctorByTzAsync(int Tz)
        {
             return await _doctorRepository.GetDoctorByTzAsync(Tz);

        }
        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }
        public async Task<Doctor> AddDoctorAsync(Doctor d)
        {
           return await _doctorRepository.AddDoctorAsync(d);
        }
        public async Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor)
        {
           var d = await _doctorRepository.UpdateDoctorAsync(id,doctor);
           return d;
        }
        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
        }

      
    }
}
