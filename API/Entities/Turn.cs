namespace API.Entities
{
    public class Turn
    {
        public Turn(DateTime date, int hour, int treatmentDuration)
        {
            Date = date;
            hour = hour;
            this.treatmentDuration = treatmentDuration;
        }

        public DateTime Date { get; set; }
        public int hour { get; set; }
        public int treatmentDuration { get; set; }
       

    }
}
