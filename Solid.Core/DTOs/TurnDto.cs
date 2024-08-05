using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class TurnDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int TreatmentDuration { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public PatientDto patientDto { get; set; }
        public DoctorDto doctorDto { get; set; }

    }
}
