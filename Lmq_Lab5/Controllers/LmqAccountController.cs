using Microsoft.AspNetCore.Mvc;
using Lmq_Lab5.Models;
using System.Text.RegularExpressions;

namespace Lmq_Lab5.Controllers
{
    public class LmqAccountController : Controller
    {
        // Danh sách lưu tạm
        private static List<LmqAccount> accounts = new List<LmqAccount>();

        // GET: LmqAccountController
        public ActionResult LmqIndex()
        {
            return View(accounts);
        }

        // GET: LmqAccountController/Details/5
        public ActionResult LmqDetails(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
        // GET: LmqAccountController/Create
        public ActionResult LmqCreate()
        {
            LmqAccount model = new LmqAccount();

            return View(model);
        }

        // POST: LmqAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LmqCreate(LmqAccount model)
        {
            if (ModelState.IsValid)
            {
                // Thêm tài khoản vào danh sách
                model.Id = accounts.Count + 1;
                accounts.Add(model);

                return RedirectToAction(nameof(LmqIndex));
            }

            return View(model);
        }

        // GET: LmqAccountController/Edit/5
        public ActionResult LmqEdit(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: LmqAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LmqEdit(int id, LmqAccount model)
        {
            if (ModelState.IsValid)
            {
                var account = accounts.FirstOrDefault(x => x.Id == id);

                if (account == null)
                {
                    return NotFound();
                }

                account.FullName = model.FullName;
                account.Email = model.Email;
                account.Phone = model.Phone;
                account.Address = model.Address;
                account.Avatar = model.Avatar;
                account.Birthday = model.Birthday;
                account.Gender = model.Gender;
                account.Password = model.Password;
                account.Facebook = model.Facebook;

                return RedirectToAction(nameof(LmqIndex));
            }

            return View(model);
        }

        // GET: LmqAccountController/Delete/5
        public ActionResult LmqDelete(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: LmqAccountController/Delete/5
        [HttpPost]
        [ActionName("LmqDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LmqDeleteConfirmed(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            accounts.Remove(account);

            return RedirectToAction(nameof(LmqIndex));
        }

        // Remote Validation
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(
                @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"
            );

            if (!_isPhone.IsMatch(phone))
            {
                return Json(
                    $"Số điện thoại {phone} không đúng định dạng, VD: 0986421127 hoặc 098.421.1127"
                );
            }

            return Json(true);
        }
    }
}