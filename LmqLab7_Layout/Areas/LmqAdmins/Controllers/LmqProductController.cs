using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LmqLab7_Layout.Areas.LmqAdmins.Data;
using LmqLab7_Layout.Areas.LmqAdmins.Models;

namespace LmqLab7_Layout.Areas.LmqAdmins.Controllers
{
    [Area("LmqAdmins")]
    public class LmqProductController : Controller
    {
        private readonly LmqLab7DbContext _context;

        public LmqProductController(LmqLab7DbContext context)
        {
            _context = context;
        }

        // =========================
        // DANH SÁCH SẢN PHẨM
        // =========================
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            return View(products);
        }

        // =========================
        // NẠP DANH SÁCH DANH MỤC
        // =========================
        private async Task LoadCategoriesAsync(int? selectedId = null)
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();

            ViewBag.CategoryId = new SelectList(
                categories,
                "Id",
                "Name",
                selectedId
            );
        }

        // =========================
        // HIỂN THỊ FORM THÊM
        // =========================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategoriesAsync();
            return View();
        }

        // =========================
        // XỬ LÝ THÊM SẢN PHẨM
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            // Kiểm tra tên sản phẩm
            if (!string.IsNullOrWhiteSpace(product.Name))
            {
                bool nameExists = await _context.Products
                    .AnyAsync(p => p.Name == product.Name);

                if (nameExists)
                {
                    ModelState.AddModelError(
                        nameof(product.Name),
                        "Tên sản phẩm đã tồn tại."
                    );
                }
            }

            // Kiểm tra danh mục
            bool categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == product.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(
                    nameof(product.CategoryId),
                    "Vui lòng chọn danh mục hợp lệ."
                );
            }

            // Kiểm tra giá
            if (product.Price < 0)
            {
                ModelState.AddModelError(
                    nameof(product.Price),
                    "Giá gốc không được âm."
                );
            }

            if (product.SalePrice.HasValue &&
                product.SalePrice.Value < 0)
            {
                ModelState.AddModelError(
                    nameof(product.SalePrice),
                    "Giá khuyến mãi không được âm."
                );
            }

            if (product.SalePrice.HasValue &&
                product.SalePrice.Value > product.Price)
            {
                ModelState.AddModelError(
                    nameof(product.SalePrice),
                    "Giá khuyến mãi không được lớn hơn giá gốc."
                );
            }

            // Nếu có lỗi thì hiển thị lại form
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState
                    .Where(x => x.Value != null &&
                                x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value!.Errors.Select(e =>
                        string.IsNullOrWhiteSpace(e.ErrorMessage)
                            ? "Dữ liệu nhập không hợp lệ."
                            : $"{x.Key}: {e.ErrorMessage}"))
                    .ToList();

                await LoadCategoriesAsync(product.CategoryId);
                return View(product);
            }

            // Gán ngày tạo tự động
            product.CreatedDate = DateTime.Now;

            // Lưu vào cơ sở dữ liệu
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm sản phẩm thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể lưu sản phẩm vào cơ sở dữ liệu. " +
                    "Hãy kiểm tra cấu trúc bảng Product và các ràng buộc."
                );

                await LoadCategoriesAsync(product.CategoryId);
                return View(product);
            }
        }

        // =========================
        // HIỂN THỊ FORM SỬA
        // =========================
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            await LoadCategoriesAsync(product.CategoryId);
            return View(product);
        }

        // =========================
        // XỬ LÝ SỬA SẢN PHẨM
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(product.Name))
            {
                bool nameExists = await _context.Products
                    .AnyAsync(p => p.Name == product.Name &&
                                   p.Id != product.Id);

                if (nameExists)
                {
                    ModelState.AddModelError(
                        nameof(product.Name),
                        "Tên sản phẩm đã tồn tại."
                    );
                }
            }

            bool categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == product.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError(
                    nameof(product.CategoryId),
                    "Vui lòng chọn danh mục hợp lệ."
                );
            }

            if (product.Price < 0)
            {
                ModelState.AddModelError(
                    nameof(product.Price),
                    "Giá gốc không được âm."
                );
            }

            if (product.SalePrice.HasValue &&
                product.SalePrice.Value < 0)
            {
                ModelState.AddModelError(
                    nameof(product.SalePrice),
                    "Giá khuyến mãi không được âm."
                );
            }

            if (product.SalePrice.HasValue &&
                product.SalePrice.Value > product.Price)
            {
                ModelState.AddModelError(
                    nameof(product.SalePrice),
                    "Giá khuyến mãi không được lớn hơn giá gốc."
                );
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState
                    .Where(x => x.Value != null &&
                                x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value!.Errors.Select(e =>
                        string.IsNullOrWhiteSpace(e.ErrorMessage)
                            ? "Dữ liệu nhập không hợp lệ."
                            : $"{x.Key}: {e.ErrorMessage}"))
                    .ToList();

                await LoadCategoriesAsync(product.CategoryId);
                return View(product);
            }

            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.SalePrice = product.SalePrice;
            existingProduct.Status = product.Status;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Image = product.Image;
            existingProduct.Description = product.Description;

            try
            {
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cập nhật sản phẩm thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Không thể cập nhật sản phẩm. " +
                    "Hãy kiểm tra các ràng buộc trong cơ sở dữ liệu."
                );

                await LoadCategoriesAsync(product.CategoryId);
                return View(product);
            }
        }


        // =========================
        // CHI TIẾT SẢN PHẨM
        // =========================
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }


        // =========================
        // XÁC NHẬN XÓA
        // =========================
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // =========================
        // XỬ LÝ XÓA
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa sản phẩm thành công.";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] =
                    "Không thể xóa sản phẩm vì dữ liệu đang được tham chiếu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}