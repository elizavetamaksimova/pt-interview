using BravissimoStudio.Models;
using System.Collections.Generic;

namespace BravissimoStudio.DA.Repositories
{
    public class TeachersRepository: BaseRepository
    {
        public string[] SelectAllTeachers()
        {
            string selectTeachersQuery = @"SELECT name FROM Teachers";

            var teachersList = new List<string>();

            ReadDelegate teacherReader = (reader) =>
            {
                teachersList.Add(reader.GetString(0));
            };

            Read(selectTeachersQuery, teacherReader);

            return teachersList.ToArray();
        }

        public Teacher[] SelectAggregatedTeachers()
        {
            string selectAggregatedTeachersQuery = 
                @"SELECT t.name AS Name, 
		                COUNT(1) AS LessonsCount,
		                t.fixed_salary AS Salary,
		                t.hour_rate AS HourRate,
		                t.fixed_salary + SUM(t.hour_rate * 2 * c.coefficient) AS TotalPayment
                FROM Lessons AS l
                JOIN Courses AS c
	                ON c.id = l.course_id
                JOIN Teachers AS t
	                ON t.id = l.teacher_id
                GROUP BY l.teacher_id, t.name, t.fixed_salary, t.hour_rate";

            var teachersList = new List<Teacher>();

            ReadDelegate teacherReader = (reader) =>
            {
                var teacher = new Teacher
                {
                    Name = reader.GetString(0),
                    LessonsCount = reader.GetInt32(1),
                    FixedSalary = reader.GetDouble(2),
                    HourRate = reader.GetInt32(3),
                    TotalPayment = reader.GetDouble(4)
                };

                teachersList.Add(teacher);
            };

            Read(selectAggregatedTeachersQuery, teacherReader);

            return teachersList.ToArray();
        }
    }
}
