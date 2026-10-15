using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmqLab7_Layout.Areas.LmqAdmins.Data;
using LmqLab7_Layout.Areas.LmqAdmins.Models;

namespace LmqLab7_Layout.Areas.LmqAdmins.Controllers
{
    [Area("LmqAdmins")]
    public class LmqCategoryController : Controller
    {
        private readonly LmqLab7DbContext _context;

        public LmqCategoryController(LmqLab7DbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách danh mục
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            return View(categories);
        }

        // Hiển thị form thêm
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (await _context.Categories.AnyAsync(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category.CreatedDate = DateTime.Now;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Hiển thị form sửa
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Xử lý sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (await _context.Categories.AnyAsync(c =>
                c.Name == category.Name && c.Id != category.Id))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;
            existingCategory.Status = category.Status;
            existingCategory.Image = category.Image;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Hiển thị trang xác nhận xóa
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (await _context.Products.AnyAsync(p => p.CategoryId == id))
            {
                TempData["Error"] =
                    "Không thể xóa danh mục đang có sản phẩm. Hãy chuyển sản phẩm sang danh mục khác trước.";

                return RedirectToAction(nameof(Index));
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}