using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LeMinhQuan_241230827.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _db;

        public HomeController(QLTaiSanContext db)
        {
            _db = db;
        }

        private List<TaiSan> LayTaiSanGiaTriCao()
        {
            return _db.TaiSans.Where(t => t.NguyenGia != null && t.NguyenGia >= 20).ToList();
        }

        public IActionResult Index()
        {
            ViewData["TieuDe"] = "Lê Minh Quân";

            return View(LayTaiSanGiaTriCao());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<TaiSan> LayTaiSanTheoLoai(int maLoai)
        {
            return _db.TaiSans.Where(t => t.MaLoai == maLoai).ToList();
        }

        [HttpGet]
        public IActionResult LocTheoLoai(int maLoai)
        {
            var loai = _db.LoaiTaiSans.Find(maLoai);
            if (loai == null) return NotFound();

            ViewData["TieuDe"] = loai.TenLoai;
            return PartialView("LeMinhQuan_DanhSachTS", LayTaiSanTheoLoai(maLoai));
        }

        
        private void NapDanhSachLoai(int? maLoaiChon = null)
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", maLoaiChon);
        }

        [HttpGet]
        public IActionResult Create()
        {
            NapDanhSachLoai();
            return View(new TaiSan());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,TenTs,NguyenGia,Anh")] TaiSan ts)
        {
           
            ModelState.Remove("MaLoaiNavigation");

            if (!ModelState.IsValid)
            {
                NapDanhSachLoai(ts.MaLoai);
                return View(ts);
            }

            _db.TaiSans.Add(ts);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
