
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{ 
    public class PatientRepository:IPatientRepository
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
        public async Task<Patient> AddPatientAsync(Patient p)
        {
            _dataContext.Patients.Add(p);
            await _dataContext.SaveChangesAsync();
            return p;
        }
        public async Task<Patient> UpdatePatientAsync(int id,Patient p)
        {
            var pat = await _dataContext.Patients.FirstAsync(d => d.Id == id);
            pat.FirstName = p.FirstName;
            pat.LastName = p.LastName;
            pat.Age = p.Age;
            await _dataContext.SaveChangesAsync();
            return pat;
        }



        public async Task DeletePatientAsync(int id)
        {
            var p =await _dataContext.Patients.FirstAsync(d => d.Id == id);
             _dataContext.Patients.Remove(p);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int Id)
        {
            var p = await _dataContext.Patients.FirstAsync(e => e.Id == Id);
            return p;
        }
    }
}
