
using Microsoft.AspNetCore.Mvc;
using LmqLab.Data;

namespace LmqLab.Controllers
{
    public class LmqDashboardController : Controller
    {
        private readonly LmqSchoolContext db;

        public LmqDashboardController(LmqSchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalLearners = db.Learners.Count();
            ViewBag.TotalMajors = db.Majors.Count();
            ViewBag.TotalCourses = db.Courses.Count();

            return View();
        }
    }
}
