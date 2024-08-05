using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solid.Core.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByTzAsync(int Tz);
        Task<Patient> GetPatientByIdAsync(int Id);
        Task<Patient> AddPatientAsync(Patient p);
        Task<Patient> UpdatePatientAsync(int id, Patient pat);
        Task DeletePatientAsync(int id);

    }
}
