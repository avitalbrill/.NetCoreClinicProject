namespace Solid.Core.Entities
{
    public class Turn
    {
        public int  Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int TreatmentDuration { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }    
        public Patient  Patient { get; set; }

    }
}
