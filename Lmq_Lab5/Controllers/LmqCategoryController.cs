using Microsoft.AspNetCore.Mvc;
using Lmq_Lab5.Models;

namespace Lmq_Lab5.Controllers
{
    public class LmqCategoryController : Controller
    {
        // Danh sách Category lưu tạm
        private static List<LmqCategory> categories = new List<LmqCategory>()
        {
            new LmqCategory
            {
                Id = 1,
                Name = "Điện thoại"
            },

            new LmqCategory
            {
                Id = 2,
                Name = "Laptop"
            },

            new LmqCategory
            {
                Id = 3,
                Name = "Phụ kiện"
            },

            new LmqCategory
            {
                Id = 4,
                Name = "Thời trang"
            }
        };

        // GET: LmqCategory/LmqIndex
        public IActionResult LmqIndex()
        {
            return View(categories);
        }
    }
}