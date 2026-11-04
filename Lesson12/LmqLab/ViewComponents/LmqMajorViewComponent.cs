using Microsoft.AspNetCore.Mvc;
using LmqLab.Data;
using LmqLab.Models;

namespace LmqLab.ViewComponents
{
    public class LmqMajorViewComponent : ViewComponent
    {
        private readonly LmqSchoolContext db;

        public LmqMajorViewComponent(LmqSchoolContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Major> majors = db.Majors.ToList();

            return View("LmqRenderMajor", majors);
        }
    }
}