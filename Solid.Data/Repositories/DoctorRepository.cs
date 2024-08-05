using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _dataContext;

        public DoctorRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _dataContext.Doctors.Include(d => d.Turns).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _dataContext.Doctors
                .Include(d => d.Turns)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Doctor> AddDoctorAsync(Doctor d)
        {
            _dataContext.Doctors.Add(d);
            await _dataContext.SaveChangesAsync();
            return await GetDoctorByIdAsync(d.Id);
        }

        public async Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor)
        {
            var d = await _dataContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (d != null)
            {
                d.FirstName = doctor.FirstName;
                d.LastName = doctor.LastName;
                d.Domain = doctor.Domain;
                await _dataContext.SaveChangesAsync();
                return await GetDoctorByIdAsync(id);
            }
            return null;
        }
        public async Task<Doctor> GetDoctorByTzAsync(int Tz)
        {
            var d = await _dataContext.Doctors.FirstAsync(e => e.Tz == Tz);
            return d;

        }

        public async Task DeleteDoctorAsync(int id)
        {
            var d = await _dataContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (d != null)
            {
                _dataContext.Doctors.Remove(d);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

