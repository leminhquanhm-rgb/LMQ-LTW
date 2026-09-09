using Lmq_BTTL_Lab3.Models;
using Microsoft.AspNetCore.Mvc;


namespace Lmq_BTTL_Lab3.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        protected Product product = new Product();

        public IViewComponentResult Invoke()
        {
            var products = product.GetProductList();
            return View(products);
        }
    }
}