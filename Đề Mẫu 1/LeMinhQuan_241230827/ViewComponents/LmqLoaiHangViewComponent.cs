
using LeMinhQuan_241230827.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeMinhQuan_241230827.ViewComponents
{
    public class LmqLoaiHangViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext db;

        public LmqLoaiHangViewComponent(QlhangHoaContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dsLoai = await db.LoaiHangs.ToListAsync();

            return View(dsLoai);
        }
    }
}
