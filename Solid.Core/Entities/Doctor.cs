namespace Solid.Core.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int Tz{ get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public  string Domain { get; set; }
        public List<Turn> Turns { get; set; }

    }
}
