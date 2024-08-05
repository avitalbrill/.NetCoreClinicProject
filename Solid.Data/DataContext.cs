using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Solid.Data
{
    public class DataContext : DbContext

    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Turn> Turns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=avit_db");
        }


        //public DataContext()
        //{
        //    Doctors = new List<Doctor> { new Doctor { Tz=000000000,FirstName="default",LastName="default",Domain="default" } };
        //    Patients = new List<Patient> { new Patient { Tz = 000000000, FirstName = "default", LastName = "default", Age = 0 } };
        //    Turns = new List<Turn> { new Turn { Date=DateTime.Now, Hour=0000, TreatmentDuration=15} };
        //}


    }
}
