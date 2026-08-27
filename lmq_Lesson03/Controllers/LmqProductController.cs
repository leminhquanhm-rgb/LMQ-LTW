using lmq_Lesson03.Models;
using Microsoft.AspNetCore.Mvc;

namespace lmq_Lesson03.Controllers
{
    public class LmqProductController : Controller
    {
        public IActionResult Index()
        {
            //Tạo 1 sản phẩm
            var product = new LmqProduct(){
                productId = "P001",
                productName = "ASUS",
                quantity = 100,
                price = 1200
            };

            ViewBag.productVB = product;
            ViewData["productVD"] = product;
          

            return View();
        }
        public IActionResult GetAllProducts()
        {
            //Tạo mock data
            List<LmqProduct> products = new List<LmqProduct>
            {
                new LmqProduct { productId = "SP001", productName = "Bàn phím cơ AKKO",       quantity = 25, price = 850000m },
                new LmqProduct { productId = "SP002", productName = "Chuột không dây Logitech", quantity = 40, price = 350000m },
                new LmqProduct { productId = "SP003", productName = "Tai nghe Sony WH-1000XM4", quantity = 10, price = 6500000m },
                new LmqProduct { productId = "SP004", productName = "Màn hình Dell 24 inch",   quantity = 15, price = 3200000m },
                new LmqProduct { productId = "SP005", productName = "Laptop Asus Vivobook",   quantity = 8,  price = 15500000m },
                new LmqProduct { productId = "SP006", productName = "Ổ cứng SSD 512GB",       quantity = 30, price = 1200000m },
                new LmqProduct { productId = "SP007", productName = "Webcam Logitech C920",   quantity = 20, price = 1500000m },
                new LmqProduct { productId = "SP008", productName = "Loa Bluetooth JBL Flip 5", quantity = 18, price = 2200000m },
                new LmqProduct { productId = "SP009", productName = "Sạc dự phòng Anker 10000mAh", quantity = 50, price = 650000m },
                new LmqProduct { productId = "SP010", productName = "Balo laptop Targus",     quantity = 12, price = 750000m }
            };

            //Lưu vào đối tượng viewdata để chuyển lên view
            ViewData["products"] = products;
            return View("Product");
        }

    }
}
