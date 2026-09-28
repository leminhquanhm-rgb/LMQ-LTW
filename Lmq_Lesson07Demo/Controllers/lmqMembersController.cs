using Lmq_Lesson07Demo.Models.DataModels;
using Lmq_Lesson07Demo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_Lesson07Demo.Controllers
{
    public class lmqMembersController : Controller
    {
        public static readonly List<LmqMember> _lmqMembers = new List<LmqMember>();

        public IActionResult LmqIndex()
        {
            return View(_lmqMembers);
        }

        public IActionResult LmqCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LmqCreate(LmqRegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                LmqMember m = new LmqMember
                {
                    lmqMemberId = Guid.NewGuid().ToString(),
                    lmqUserName = register.lmqUserName,
                    lmqFullName = register.lmqFullName,
                    lmqEmail = register.lmqEmail,
                    lmqPassword = register.lmqPassword,
                    lmqPhone = register.lmqPhone,
                    lmqBirthday = register.lmqBirthday
                };

                _lmqMembers.Add(m);

                return RedirectToAction("LmqIndex");
            }
            else
            {
                return View(register);
            }
        }
    }
}