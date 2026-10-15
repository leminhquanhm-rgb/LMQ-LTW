using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using LmqLab7_Layout.Areas.LmqAdmins.Data;
using LmqLab7_Layout.Areas.LmqAdmins.Models;

namespace LmqLab7_Layout.Areas.LmqAdmins.Controllers
{
    [Area("LmqAdmins")]
    public class LmqBlogController : Controller
    {
        private readonly LmqLab7DbContext _context;

        public LmqBlogController(LmqLab7DbContext context)
        {
            _context = context;
        }

        // Danh sách bài viết
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs
                .AsNoTracking()
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();

            return View(blogs);
        }

        // Form thêm bài viết
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm bài viết
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!string.IsNullOrWhiteSpace(blog.Name) &&
                await _context.Blogs.AnyAsync(b => b.Name == blog.Name))
            {
                ModelState.AddModelError(
                    nameof(blog.Name),
                    "Tên bài viết đã tồn tại.");
            }

            if (!ModelState.IsValid)
                return View(blog);

            blog.CreatedDate = DateTime.Now;

            try
            {
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm bài viết thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể lưu bài viết. Hãy kiểm tra cấu trúc bảng Blog.");

                return View(blog);
            }
        }

        // Chi tiết bài viết
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = await _context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        // Form sửa bài viết
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        // Xử lý sửa bài viết
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog blog)
        {
            if (id != blog.Id)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(blog.Name) &&
                await _context.Blogs.AnyAsync(b =>
                    b.Name == blog.Name && b.Id != blog.Id))
            {
                ModelState.AddModelError(
                    nameof(blog.Name),
                    "Tên bài viết đã tồn tại.");
            }

            if (!ModelState.IsValid)
                return View(blog);

            var existingBlog = await _context.Blogs.FindAsync(id);

            if (existingBlog == null)
                return NotFound();

            existingBlog.Name = blog.Name;
            existingBlog.Status = blog.Status;
            existingBlog.Image = blog.Image;
            existingBlog.Description = blog.Description;

            try
            {
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cập nhật bài viết thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể cập nhật bài viết.");

                return View(blog);
            }
        }

        // Xác nhận xóa
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = await _context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        // Xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound();

            try
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa bài viết thành công.";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] =
                    "Không thể xóa bài viết do ràng buộc dữ liệu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}