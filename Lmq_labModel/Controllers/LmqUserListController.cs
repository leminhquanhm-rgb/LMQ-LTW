using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqUserListController : Controller
    {
        public IActionResult Index()
        {
            var lmqUsers = new List<LmqUser>();

            var lmqUser1 = new LmqUser();
            lmqUser1.Id = 1;
            lmqUser1.Name = "Lê Minh Quân";
            lmqUser1.Address = "Nghệ An";
            lmqUser1.Email = "leminhquan@gmail.com";

            var lmqUser2 = new LmqUser();
            lmqUser2.Id = 2;
            lmqUser2.Name = "Nguyễn Văn A";
            lmqUser2.Address = "Hà Nội";
            lmqUser2.Email = "nguyenvana@gmail.com";

            var lmqUser3 = new LmqUser();
            lmqUser3.Id = 3;
            lmqUser3.Name = "Trần Văn B";
            lmqUser3.Address = "Đà Nẵng";
            lmqUser3.Email = "tranvanb@gmail.com";

            lmqUsers.Add(lmqUser1);
            lmqUsers.Add(lmqUser2);
            lmqUsers.Add(lmqUser3);

            return View(lmqUsers);
        }
    }
}