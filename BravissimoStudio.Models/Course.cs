using System;

namespace BravissimoStudio.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public double Coefficient { get; set; }

        public int LessonsCount { get; set; }

        public string[] TeachersInvolved { get; set; }
    }
}
