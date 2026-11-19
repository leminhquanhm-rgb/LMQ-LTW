using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeMinhQuan_241230827.ViewComponents;

public class LeMinhQuan_MenuViewComponent : ViewComponent
{
    private readonly QLNhaSachContext _db;

    public LeMinhQuan_MenuViewComponent(QLNhaSachContext db)
    {
        _db = db;
    }

    public IViewComponentResult Invoke()
    {
        return View(_db.TheLoais.ToList());
    }
}