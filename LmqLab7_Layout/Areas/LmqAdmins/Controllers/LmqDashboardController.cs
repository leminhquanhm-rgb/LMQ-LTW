
using Microsoft.AspNetCore.Mvc;

namespace LmqLab7_Layout.Areas.LmqAdmins.Controllers
{
    [Area("LmqAdmins")]
    public class LmqDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
