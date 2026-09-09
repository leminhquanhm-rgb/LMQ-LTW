using Lmq_BTTL_Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lmq_BTTL_Lab3.Controllers
{
    public class HomeController : Controller
    {
        protected Product product = new Product();

        public IActionResult Index()
        {
            var products = product.GetProductList();
            return View(products); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
