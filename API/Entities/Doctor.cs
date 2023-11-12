namespace API
{
    public class Doctor
    {
        public Doctor(int tz, string firstName, string lastName, string domain)
        {
            this.tz = tz;
            this.firstName = firstName;
            this.lastName = lastName;
            this.domain = domain;
        }

        public int tz{ get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public  string domain { get; set; }




    }
}
