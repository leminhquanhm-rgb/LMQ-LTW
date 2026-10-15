using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmqLab7_Layout.Areas.LmqAdmins.Data;
using LmqLab7_Layout.Areas.LmqAdmins.Models;

namespace LmqLab7_Layout.Areas.LmqAdmins.Controllers
{
    [Area("LmqAdmins")]
    public class LmqBannerController : Controller
    {
        private readonly LmqLab7DbContext _context;

        public LmqBannerController(LmqLab7DbContext context)
        {
            _context = context;
        }

        // Danh sách Banner
        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners
                .AsNoTracking()
                .OrderBy(b => b.Priority)
                .ThenBy(b => b.Id)
                .ToListAsync();

            return View(banners);
        }

        // Form thêm Banner
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm Banner
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (!string.IsNullOrWhiteSpace(banner.Name) &&
                await _context.Banners.AnyAsync(b => b.Name == banner.Name))
            {
                ModelState.AddModelError(
                    nameof(banner.Name),
                    "Tên Banner đã tồn tại.");
            }

            if (banner.Priority < 0)
            {
                ModelState.AddModelError(
                    nameof(banner.Priority),
                    "Độ ưu tiên không được âm.");
            }

            if (!ModelState.IsValid)
                return View(banner);

            try
            {
                _context.Banners.Add(banner);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm Banner thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể lưu Banner. Hãy kiểm tra cấu trúc bảng Banner.");

                return View(banner);
            }
        }

        // Chi tiết Banner
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var banner = await _context.Banners
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        // Form sửa Banner
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var banner = await _context.Banners.FindAsync(id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        // Xử lý sửa Banner
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (id != banner.Id)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(banner.Name) &&
                await _context.Banners.AnyAsync(b =>
                    b.Name == banner.Name && b.Id != banner.Id))
            {
                ModelState.AddModelError(
                    nameof(banner.Name),
                    "Tên Banner đã tồn tại.");
            }

            if (banner.Priority < 0)
            {
                ModelState.AddModelError(
                    nameof(banner.Priority),
                    "Độ ưu tiên không được âm.");
            }

            if (!ModelState.IsValid)
                return View(banner);

            var existingBanner = await _context.Banners.FindAsync(id);

            if (existingBanner == null)
                return NotFound();

            existingBanner.Name = banner.Name;
            existingBanner.Status = banner.Status;
            existingBanner.Priority = banner.Priority;
            existingBanner.Image = banner.Image;
            existingBanner.Description = banner.Description;

            try
            {
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cập nhật Banner thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể cập nhật Banner.");

                return View(banner);
            }
        }

        // Xác nhận xóa Banner
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var banner = await _context.Banners
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        // Xử lý xóa Banner
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);

            if (banner == null)
                return NotFound();

            try
            {
                _context.Banners.Remove(banner);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa Banner thành công.";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] =
                    "Không thể xóa Banner do ràng buộc dữ liệu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}