using Microsoft.AspNetCore.Mvc;
using lmq_lesson10_lab1.Models;
using System.Collections.Generic;

namespace lmq_lesson10_lab1.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Danh sách các mục menu giả lập y hệt tài liệu
            var menuItems = new List<LmqMenuItem>
            {
                new LmqMenuItem { Id = "1", Name = "Branches", Link = "/Branches", Icon = "fas fa-code-branch" },
                new LmqMenuItem { Id = "2", Name = "Students", Link = "/Student", Icon = "fas fa-user-graduate" },
                new LmqMenuItem { Id = "3", Name = "Subjects", Link = "/Subjects", Icon = "fas fa-book" },
                new LmqMenuItem { Id = "4", Name = "Courses", Link = "/Courses", Icon = "fas fa-graduation-cap" }
            };

            return View("RenderLeftMenu", menuItems); // Trả về đúng view RenderLeftMenu.cshtml
        }
    }
}