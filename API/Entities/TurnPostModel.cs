namespace Solid.API.Entities
{
    public class TurnPostModel
    {
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int TreatmentDuration { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
