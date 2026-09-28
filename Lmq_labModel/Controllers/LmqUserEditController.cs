using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqUserEditController : Controller
    {
        // Hiển thị form Edit
        public IActionResult Edit()
        {
            var lmqUser = new LmqUser();

            lmqUser.Id = 1;
            lmqUser.Name = "Lê Minh Quân";
            lmqUser.Address = "Nghệ An";
            lmqUser.Email = "leminhquan@gmail.com";

            return View(lmqUser);
        }

        // Nhận dữ liệu sau khi sửa
        [HttpPost]
        public IActionResult Edit(LmqUser lmqUser)
        {
            return View(lmqUser);
        }
    }
}