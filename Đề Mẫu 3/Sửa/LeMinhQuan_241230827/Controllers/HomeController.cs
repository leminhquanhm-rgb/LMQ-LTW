using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;
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
            return _db.TaiSans
                      .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                      .ToList();
        }

        public IActionResult Index()
        {
            ViewData["TieuDe"] = "Lê Minh Quân";
            return View(LayTaiSanGiaTriCao());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
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
        public IActionResult Edit(int id)
        {
            var ts = _db.TaiSans.Find(id);
            if (ts == null) return NotFound();

            NapDanhSachLoai(ts.MaLoai);
            return View(ts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MaTs, MaLoai, TenTs, NguyenGia, Anh")] TaiSan form)
        {
            if (id != form.MaTs) return NotFound();

            ModelState.Remove("MaLoaiNavigation");
            if (!ModelState.IsValid)
            {
                NapDanhSachLoai(form.MaLoai);
                return View(form);
            }

            var ts = _db.TaiSans.Find(id);
            if(ts == null) return NotFound();

            CapNhatTaiSan(ts, form);
            _db.SaveChanges();
            return RedirectToAction("Index");
          
        }

        private void CapNhatTaiSan(TaiSan goc, TaiSan moi)
        {
            goc.MaLoai = moi.MaLoai;
            goc.TenTs = moi.TenTs;
            goc.NguyenGia = moi.NguyenGia;
            goc.Anh = moi.Anh;
        }







    }
}