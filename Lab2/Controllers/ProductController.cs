using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab2.Controllers
{
    public class ProductController : Controller
    {
        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần Áo" },
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" },
                new Category { Id = 7, Name = "Quạt điện" },
                new Category { Id = 8, Name = "Lò sưởi" }
            };
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1, Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = Url.Content("~/images/products/01.jpg"),
                    Price = 50000, SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde iure doloribus natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.",
                    Status = true,
                    CreatedAt = new DateTime(2021, 7, 15)
                },
                new Product
                {
                    Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ",
                    Image = Url.Content("~/images/products/02.jpg"),
                    Price = 50000, SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                    Status = true,
                    CreatedAt = new DateTime(2021, 7, 15)
                },
                new Product
                {
                    Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Image = Url.Content("~/images/products/03.jpg"),
                    Price = 50000, SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                    Status = true,
                    CreatedAt = new DateTime(2021, 7, 15)
                },
                new Product
                {
                    Id = 4, Name = "Túi thời trang mẫu mới 2021",
                    Image = Url.Content("~/images/products/04.jpg"),
                    Price = 50000, SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                    Status = true,
                    CreatedAt = new DateTime(2021, 7, 15)
                },
                new Product
                {
                    Id = 5, Name = "Túi thời trang da cá sấu",
                    Image = Url.Content("~/images/products/05.jpg"),
                    Price = 50000, SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                    Status = true,
                    CreatedAt = new DateTime(2021, 7, 15)
                }
            };
        }

        // GET: /san-pham hoặc /san-pham?categoryId=1
        [Route("san-pham", Name = "product-index")]
        public IActionResult Index(int? categoryId)
        {
            List<Product> products = GetProducts();
            List<Category> categories = GetCategories();

            // nếu có chọn danh mục thì lọc theo categoryId
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Products = products;
            ViewBag.Categories = categories;
            return View();
        }

        // GET: /san-pham/chi-tiet/1
        [Route("san-pham/chi-tiet/{id}", Name = "product-detail")]
        public IActionResult Detail(int id)
        {
            List<Product> products = GetProducts();
            Product product = products.FirstOrDefault(p => p.Id == id);

            ViewBag.Product = product;
            return View();
        }
    }
}
