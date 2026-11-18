
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeMinhQuan_241230827.Models;

namespace LeMinhQuan_241230827.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly QlhangHoaContext db;

        public HangHoaController(QlhangHoaContext context)
        {
            db = context;
        }

        public IActionResult Index(int? maLoai)
        {
            var dsHangHoa = db.HangHoas
                .Where(x => x.Gia >= 100);

            if (maLoai != null)
            {
                dsHangHoa = dsHangHoa
                    .Where(x => x.MaLoai == maLoai);
            }

            var ketQua = dsHangHoa.ToList();

            // Nếu là yêu cầu AJAX
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DanhSachHangHoa", ketQua);
            }

            // Nếu truy cập bình thường
            return View(ketQua);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (!db.LoaiHangs.Any(l => l.MaLoai == hangHoa.MaLoai))
            {
                ModelState.AddModelError("MaLoai", "Loại hàng không tồn tại");
            }

            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}
