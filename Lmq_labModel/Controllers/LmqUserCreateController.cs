using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqUserCreateController : Controller
    {
        // Hiển thị form Create
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ form
        [HttpPost]
        public IActionResult Create(LmqUser lmqUser)
        {
            return View(lmqUser);
        }
    }
}