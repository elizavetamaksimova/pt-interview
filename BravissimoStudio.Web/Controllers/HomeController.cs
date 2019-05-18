using BravissimoStudio.BL;
using BravissimoStudio.Models;
using BravissimoStudio.Web.Models;
using System.Web.Mvc;

namespace BravissimoStudio.Web.Controllers
{
    public class HomeController : Controller
    {
        private CoursesService _coursesService = new CoursesService();
        private TeachersService _teachersService = new TeachersService();

        public ActionResult Index()
        {
            string[] coursesNames = _coursesService.GetAllCourses();

            Course[] aggregatedCourses = _coursesService.GetAggregatedCourses();

            // _service.FilterCourses(ref aggregatedCourses, "B2", "Viktor Krasnov", 4); // not working set of data
            //_service.FilterCourses(ref aggregatedCourses, "A2", "Lucrezia Oddone", 1); // working set of data

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

            _coursesService.FilterCourses(ref aggregatedCourses, courseName, teacherName, lessonsCount); // working set of data

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
            return View();
        }
    }
}