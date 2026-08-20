using lmq_Lesson02_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lmq_Lesson02_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "CNTT2 - k65 ";
            return View();
        }

        public IActionResult Privacy()
        {      
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
