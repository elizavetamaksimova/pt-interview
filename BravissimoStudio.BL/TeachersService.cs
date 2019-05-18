using BravissimoStudio.DA.Repositories;
using BravissimoStudio.Models;
using System.Collections.Generic;
using System.Linq;

namespace BravissimoStudio.BL
{
    public class TeachersService
    {
        private TeachersRepository _teachersRepository = new TeachersRepository();

        public string[] GetAllTeachers()
        {
            return _teachersRepository.SelectAllTeachers();
        }

        public Teacher[] GetAggregatedTeachers()
        {
            string[] allTeachers = _teachersRepository.SelectAllTeachers();

            Teacher[] teachers = _teachersRepository.SelectAggregatedTeachers();

            List<Teacher> result = new List<Teacher>();

            foreach (var teacherName in allTeachers)
            {
                Teacher teacher = teachers.FirstOrDefault(t => t.Name == teacherName);

                if (teacher != null)
                {
                    result.Add(teacher);
                }
                else
                {
                    result.Add(new Teacher(teacherName));
                }
            }

            return result.ToArray();
        }
    }
}
