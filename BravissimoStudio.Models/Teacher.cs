namespace BravissimoStudio.Models
{
    public class Teacher
    {
        public string Name { get; set; }

        public int LessonsCount { get; set; }

        public double FixedSalary { get; set; }

        public int HourRate { get; set; }

        public double TotalPayment { get; set; }

        public Teacher()
        {

        }

        public Teacher(string name)
        {
            Name = name;
        }
    }
}
