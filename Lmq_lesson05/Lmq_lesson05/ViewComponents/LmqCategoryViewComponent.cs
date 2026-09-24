using Lmq_lesson05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_lesson05.ViewComponents
{
    public class LmqCategoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(bool? active)
        {
            var categories = new List<LmqCategory>
            {
                new LmqCategory(){categoryId = 1, categoryName = "SamSung", IsActive = true},
                new LmqCategory(){categoryId = 2, categoryName = "Iphone", IsActive = true},
                new LmqCategory(){categoryId = 3, categoryName = "Xiaomi", IsActive = true},
                new LmqCategory(){categoryId = 4, categoryName = "Nokia", IsActive = false},

            };
            if(active != null)
            {
                categories = categories.Where(x => x.IsActive == active.Value).ToList();
            }
            return View(categories);
        }
    }
}
