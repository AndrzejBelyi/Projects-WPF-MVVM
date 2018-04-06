namespace Texode_Test_Andrzej_Beliy.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public uint age { get; set; }
        public uint gender { get; set; }

        public Student()
        {

        }
        public Student(int id,string firstname,string lastname,uint age,uint gender)
        {
            this.id = id;
            this.firstName = firstname;
            this.lastName = lastname;
            this.age = age;
            this.gender = gender;
        }        
      
    }
}
