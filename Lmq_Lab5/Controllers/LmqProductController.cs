using Microsoft.AspNetCore.Mvc;
using Lmq_Lab5.Models;

namespace Lmq_Lab5.Controllers
{
    public class LmqProductController : Controller
    {
        // Danh sách Product lưu tạm
        private static List<LmqProduct> products = new List<LmqProduct>();

        // Danh sách Category
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

        // GET: LmqProduct/LmqIndex
        public IActionResult LmqIndex()
        {
            return View(products);
        }

        // GET: LmqProduct/LmqCreate
        public IActionResult LmqCreate()
        {
            ViewBag.Categories = categories;

            return View();
        }

        // POST: LmqProduct/LmqCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LmqCreate(
    LmqProduct model,
    IFormFile ImageFile)
        {
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError(
                    "Image",
                    "Vui lòng chọn hình ảnh");
            }

            if (ModelState.IsValid)
            {
                model.Id = products.Count + 1;

                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(ImageFile.FileName);

                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "products"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(
                    folderPath,
                    fileName
                );

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.Image = "/products/" + fileName;

                products.Add(model);

                return RedirectToAction(nameof(LmqIndex));
            }

            ViewBag.Categories = categories;

            return View(model);
        }


        // GET: LmqProduct/LmqDetails/5
        public IActionResult LmqDetails(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: LmqProduct/LmqEdit/5
        public IActionResult LmqEdit(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = categories;

            return View(product);
        }

        // POST: LmqProduct/LmqEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LmqEdit(
            int id,
            LmqProduct model,
            IFormFile? ImageFile)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Nếu có chọn ảnh mới
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(ImageFile.FileName);

                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "products"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(
                    folderPath,
                    fileName
                );

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.Image = "/products/" + fileName;
            }
            else
            {
                // Không chọn ảnh mới → giữ ảnh cũ
                model.Image = product.Image;
            }

            if (ModelState.IsValid)
            {
                product.Name = model.Name;
                product.Image = model.Image;
                product.Price = model.Price;
                product.SalePrice = model.SalePrice;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;

                return RedirectToAction(nameof(LmqIndex));
            }

            ViewBag.Categories = categories;

            return View(model);
        }

        // GET: LmqProduct/LmqDelete/5
        public IActionResult LmqDelete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: LmqProduct/LmqDelete/5
        [HttpPost]
        [ActionName("LmqDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult LmqDeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return RedirectToAction(nameof(LmqIndex));
        }

    }
}