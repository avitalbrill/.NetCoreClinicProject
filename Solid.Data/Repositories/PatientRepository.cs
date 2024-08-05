using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _dataContext;

        public PatientRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _dataContext.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientByTzAsync(int Tz)
        {
            var p = await _dataContext.Patients.FirstAsync(e => e.Tz == Tz);
            return p;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _dataContext.Patients.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Patient> AddPatientAsync(Patient p)
        {
            _dataContext.Patients.Add(p);
            await _dataContext.SaveChangesAsync();
            return await GetPatientByIdAsync(p.Id);
        }

        public async Task<Patient> UpdatePatientAsync(int id, Patient p)
        {
            var pat = await _dataContext.Patients.FirstOrDefaultAsync(d => d.Id == id);
            if (pat != null)
            {
                pat.FirstName = p.FirstName;
                pat.LastName = p.LastName;
                pat.Age = p.Age;
                await _dataContext.SaveChangesAsync();
                return await GetPatientByIdAsync(id);
            }
            return null;
        }

        public async Task DeletePatientAsync(int id)
        {
            var p = await _dataContext.Patients.FirstOrDefaultAsync(d => d.Id == id);
            if (p != null)
            {
                _dataContext.Patients.Remove(p);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

