using Lmq_lesson6_Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lmq_lesson6_Model.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult LmqAbout()
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
