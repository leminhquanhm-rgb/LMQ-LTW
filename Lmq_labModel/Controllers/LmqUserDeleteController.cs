using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqUserDeleteController : Controller
    {
        // Hiển thị thông tin User trước khi xóa
        public IActionResult Delete()
        {
            var lmqUser = new LmqUser();

            lmqUser.Id = 1;
            lmqUser.Name = "Lê Minh Quân";
            lmqUser.Address = "Nghệ An";
            lmqUser.Email = "leminhquan@gmail.com";

            return View(lmqUser);
        }

        // Xác nhận xóa
        [HttpPost]
        public IActionResult DeleteConfirmed(LmqUser lmqUser)
        {
            return RedirectToAction("Index", "LmqUserList");
        }
    }
}