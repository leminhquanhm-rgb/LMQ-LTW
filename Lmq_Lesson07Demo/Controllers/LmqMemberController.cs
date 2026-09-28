using Lmq_Lesson07Demo.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Lmq_Lesson07Demo.Controllers
{
    public class LmqMemberController : Controller
    {
        public static readonly List<LmqMember> lmqMembers = new List<LmqMember>();



        public IActionResult LmqIndex()
        {
            return View(lmqMembers);
        }

        public IActionResult LmqCreate()
        {
            return View();
        }
        [HttpPost]

        public IActionResult LmqCreate(LmqMember lmqMember)
        {

            string msg = null;
            bool validate = true;

            if (lmqMember.lmqUserName.Length < 3 || lmqMember.lmqUserName.Length > 20)
            {
                msg = "<li>Tên đăng nhập phải có độ dài từ 3-20 ký tự </li>";
                validate = false;
            }

            string patternemail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
            if (!Regex.IsMatch(lmqMember.lmqEmail, patternemail))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }

            if (lmqMember.lmqBirthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }

            string patternphone = @"^0\d{9,12}$";
            if (!Regex.IsMatch(lmqMember.lmqPhone, patternphone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }

            if (validate)
            {
                lmqMember.lmqMemberId = Guid.NewGuid().ToString();
                lmqMembers.Add(lmqMember);
                return RedirectToAction("LmqIndex");
            }
            else
            {
                ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
                return View(lmqMember);
            }
        }
    }
}
