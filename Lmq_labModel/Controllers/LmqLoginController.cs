using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LmqLogin login)
        {
            return View(login);
        }
    }
}