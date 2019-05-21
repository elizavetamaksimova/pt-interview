using BravissimoStudio.BL;
using BravissimoStudio.Models;
using BravissimoStudio.Web.Models;
using System.IO;
using System.Web.Mvc;

namespace BravissimoStudio.Web.Controllers
{
    public class HomeController : Controller
    {
        private CoursesService _coursesService = new CoursesService();
        private TeachersService _teachersService = new TeachersService();

        private readonly string CausedByPath = Path.Combine(@"C:\Users\1\Documents\Work\PT_Interview", "CausedBy.txt");
        private readonly string FixDetailsPath = Path.Combine(@"C:\Users\1\Documents\Work\PT_Interview", "FixDetails.txt");

        public ActionResult Index()
        {
            string[] coursesNames = _coursesService.GetAllCourses();

            Course[] aggregatedCourses = _coursesService.GetAggregatedCourses();
            string[] teachers = _teachersService.GetAllTeachers();

            Teacher[] aggregatedTeachers = _teachersService.GetAggregatedTeachers();

            var model = new BoardModel
            {
                Courses = coursesNames,
                AggregatedCourses = aggregatedCourses,
                Teachers = teachers,
                AggregatedTeachers = aggregatedTeachers
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult FilterCourses(string courseName, string teacherName, int? lessonsCount)
        {
            Course[] aggregatedCourses = _coursesService.GetAggregatedCourses();

            _coursesService.FilterCourses(ref aggregatedCourses, courseName, teacherName, lessonsCount);

            var model = new BoardModel
            {
                AggregatedCourses = aggregatedCourses
            };

            return PartialView("_PartialAggregatedCourses", model);
        }

        public ActionResult Tasks()
        {
            return View();
        }

        public ActionResult Report()
        {
            if (System.IO.File.Exists(CausedByPath))
            {
                using (StreamReader reader = new StreamReader(CausedByPath))
                {
                    ViewBag.CausedBy = reader.ReadToEnd();
                }
            }

            if (System.IO.File.Exists(FixDetailsPath))
            {
                using (StreamReader reader = new StreamReader(FixDetailsPath))
                {
                    ViewBag.FixDetails = reader.ReadToEnd();
                }
            }

            return View();
        }

        [HttpPost]
        public void SaveReport(string causedBy, string fixDetails)
        {
            using (StreamWriter writer = new StreamWriter(CausedByPath))
            {
                writer.Write(causedBy);
            }

            using (StreamWriter writer = new StreamWriter(FixDetailsPath))
            {
                writer.Write(fixDetails);
            }
        }
    }
}