using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeMinhQuan_241230827.Controllers;

public class SachController : Controller
{
    private readonly QLNhaSachContext _db;

    public SachController(QLNhaSachContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Create()
    {
        NapDanhSachTheLoai();
        return View(new Sach());
    }

    [HttpPost]
    public IActionResult Create(Sach sach)
    {
        // thuộc tính navigation không nhập từ form nên bỏ khỏi kiểm tra
        ModelState.Remove(nameof(Sach.MaTlNavigation));

        if (!ModelState.IsValid)
        {
            NapDanhSachTheLoai(sach.MaTl);
            return View(sach);
        }

        _db.Saches.Add(sach);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    private void NapDanhSachTheLoai(int? daChon = null)
    {
        ViewBag.DsTheLoai = new SelectList(_db.TheLoais.ToList(), "MaTl", "TenTl", daChon);
    }
}