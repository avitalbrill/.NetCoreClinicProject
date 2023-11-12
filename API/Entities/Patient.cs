namespace API
{
    public class Patient
    {
        public Patient(int tz, string firstName, string lastName,int age)
        {
            this.tz = tz;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;

            
        }

        public int tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        

    }
}
