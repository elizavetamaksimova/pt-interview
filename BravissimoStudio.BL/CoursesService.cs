using BravissimoStudio.DA;
using BravissimoStudio.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BravissimoStudio.BL
{
    public class CoursesService
    {
        private CoursesRepository _repository = new CoursesRepository();

        public string[] GetAllCourses()
        {
            return _repository.SelectAllCourses();
        }

        public Course[] GetAggregatedCourses()
        {
            var courses = _repository.SelectAggregatedCourses();
            var teachers = _repository.SelectTeachersInvolved();

            Course[] result = courses
                  .Join(teachers,
                        c => c.Id,
                        t => t.Key,
                        (c, t) => 
                        {
                            c.TeachersInvolved = t.Value.ToArray();
                            return c;
                        })
                   .ToArray();

            return result;
        }

        private void FilterByLessonsCount(Course[] coursesToFilter, int? lessonsCount)
        {
            if (lessonsCount != 0)
            {
                coursesToFilter = coursesToFilter.Where(c => c.LessonsCount >= lessonsCount).ToArray();
            }
        }

        private void FilterByName(ref Course[] coursesToFilter, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                coursesToFilter = coursesToFilter.Where(c => c.Name.Contains(name)).ToArray();
            }
        }

        private void FilterByTeacher(ref Course[] coursesToFilter, string teacher)
        {
            if (!string.IsNullOrEmpty(teacher))
            {
                coursesToFilter = coursesToFilter.Where(c => c.TeachersInvolved.Contains(teacher)).ToArray();
            }
        }

        public void FilterCourses(ref Course[] courses, string name, string teacher, int? lessonsCount)
        {
            FilterByName(ref courses, name);
            FilterByTeacher(ref courses, teacher);
            FilterByLessonsCount(courses, lessonsCount);
        }
    }
}
