using BravissimoStudio.Models;

namespace BravissimoStudio.Web.Models
{
    public class BoardModel
    {
        public string[] Courses { get; set; }

        public string[] Teachers { get; set; }

        public Course[] AggregatedCourses { get; set; }

        public Teacher[] AggregatedTeachers { get; set; }
    }
}