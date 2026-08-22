using Microsoft.AspNetCore.Mvc;

namespace lmq_Lesson02_MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
