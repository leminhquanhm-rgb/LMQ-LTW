using Microsoft.AspNetCore.Mvc;

namespace lmq_Lesson03.Controllers
{
    public class LmqAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Lê Minh Quân";
            ViewData["class"] = "CNTT2-K65";
            TempData["module"] = "Lập Trình Web";
            return View();
        }
    }
}
