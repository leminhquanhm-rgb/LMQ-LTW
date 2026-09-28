using Lmq_labModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_labModel.Controllers
{
    public class LmqUserDetailsController : Controller
    {
        public IActionResult Details()
        {
            var lmqUser = new LmqUser();

            lmqUser.Id = 1;
            lmqUser.Name = "Lê Minh Quân";
            lmqUser.Address = "Nghệ An";
            lmqUser.Email = "leminhquan@gmail.com";

            return View(lmqUser);
        }
    }
}