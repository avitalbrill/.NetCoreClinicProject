using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IPatientRepository
    {
         Task<List<Patient>> GetAllPatientsAsync();
         Task<Patient> GetPatientByTzAsync(int Tz);
         Task<Patient> AddPatientAsync(Patient p);
         Task<Patient> UpdatePatientAsync(int id, Patient p);
         Task DeletePatientAsync(int id);
         Task<Patient> GetPatientByIdAsync(int Id); 
    }
}
