using BravissimoStudio.Models;
using System.Collections.Generic;

namespace BravissimoStudio.DA
{
    public class CoursesRepository : BaseRepository
    {
        public string[] SelectAllCourses()
        {
            string selectCoursesQuery = @"SELECT name FROM Courses";

            var coursesList = new List<string>();

            ReadDelegate courseReader = (reader) =>
            {
                coursesList.Add(reader.GetString(0));
            };

            Read(selectCoursesQuery, courseReader);

            return coursesList.ToArray();
        }

        public Course[] SelectAggregatedCourses()
        {
            string selectCoursesQuery =
                @"SELECT 
                    c.id AS CourseId,
	                c.name AS Name, 
	                c.start_time AS CourseStartTime,
	                c.end_time AS CourseEndTime,
	                c.coefficient AS Coefficient,
	                COUNT(l.id) AS LastMonthCount
                FROM Courses AS c
                JOIN Lessons AS l
                    ON c.id = l.course_id
                WHERE DATEPART(m, l.lesson_date) = DATEPART(m, DATEADD(m, -1, GETDATE()))
                GROUP BY c.id, c.name, c.start_time, c.end_time, c.coefficient";

            var coursesList = new List<Course>();

            ReadDelegate courseReader = (reader) =>
            {
                var course = new Course
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    StartTime = reader.GetTimeSpan(2),
                    EndTime = reader.GetTimeSpan(3),
                    Coefficient = reader.GetDouble(4),
                    LessonsCount = reader.GetInt32(5)
                };

                coursesList.Add(course);
            };

            Read(selectCoursesQuery, courseReader);

            return coursesList.ToArray();
        }

        public Dictionary<int, List<string>> SelectTeachersInvolved()
        {
            string selectTeachersQuery =
                @"SELECT 
	                l.course_id AS CourseId,
	                t.name AS Teacher
                FROM Lessons AS l
                JOIN Teachers AS t
	                ON l.teacher_id = t.id
                WHERE DATEPART(m, l.lesson_date) = DATEPART(m, DATEADD(m, -1, GETDATE()))
                ORDER BY l.course_id";

            Dictionary<int, List<string>> teachersDict = new Dictionary<int, List<string>>();

            ReadDelegate teachersReader = (reader) =>
            {
                int courseId = reader.GetInt32(0);
                string teacher = reader.GetString(1);

                List<string> teachers = null;

                if (teachersDict.TryGetValue(courseId, out teachers))
                {
                    if (!teachers.Contains(teacher))
                    {
                        teachers.Add(teacher);
                    }
                }
                else
                {
                    teachers = new List<string>
                    {
                        teacher
                    };

                    teachersDict.Add(courseId, teachers);
                }
            };

            Read(selectTeachersQuery, teachersReader);

            return teachersDict;
        }
    }
}
