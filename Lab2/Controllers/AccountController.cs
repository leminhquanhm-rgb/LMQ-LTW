using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class AccountController : Controller
    {
        // Danh sách account mẫu - dùng chung cho Index và Profile
        private List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account()
                {
                    Id = 1, Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 2, Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 3, Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/04.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                }
            };
        }

        // GET: /Account 
        [Route("account", Name = "account")]
        public IActionResult Index()
        {
            List<Account> accounts = GetAccounts();
            ViewBag.Accounts = accounts;
            return View();
        }

        // GET: /ho-so-cua-toi?id=1
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = GetAccounts();

            // tìm account theo id (cần using System.Linq)
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            ViewBag.account = account;
            return View();
        }
    }
}
