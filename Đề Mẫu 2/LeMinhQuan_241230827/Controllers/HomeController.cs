using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeMinhQuan_241230827.Controllers;

public class HomeController : Controller
{
    private const string TEN_SV = "Lê Minh Quân";
    private readonly QLNhaSachContext _db;

    public HomeController(QLNhaSachContext db)
    {
        _db = db;
    }

    
    public IActionResult Index()
    {
        var ds = _db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
        return View(TaoViewModel(TEN_SV, ds));
    }

    
    public IActionResult SachTheoTheLoai(int maTL)
    {
        var theLoai = _db.TheLoais.Find(maTL);
        if (theLoai == null) return NotFound();

        var ds = _db.Saches.Where(s => s.MaTl == maTL && s.Gia != null).ToList();
        return PartialView("LeMinhQuan_MainContent", TaoViewModel(theLoai.TenTl, ds));
    }

    private static SachListViewModel TaoViewModel(string tieuDe, List<Sach> ds)
    {
        return new SachListViewModel { TieuDe = tieuDe, DanhSach = ds };
    }
}