using System.Collections.Generic;

namespace Lmq_BTTL_Lab3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }

        public List<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p1.jpg", Price = 2850000 },
                new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p2.jpg", Price = 2850000 },
                new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p3.jpg", Price = 2850000 },
                new Product { Id = 4, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p4.jpg", Price = 2850000 },
                new Product { Id = 5, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p5.jpg", Price = 2850000 },
                new Product { Id = 6, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/p6.jpg", Price = 2850000 },
            };
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category{Id=1, Name="Áo dài"},
                new Category{Id=2, Name="Áo dông"},
                new Category{Id=3, Name="Túi xách"},
                new Category{Id=4, Name="Đồng hồ"},
                new Category{Id=5, Name="Ví da"},
                new Category{Id=6, Name="Thắt lưng da"},
                new Category{Id=7, Name="Tủ lạnh"},
                new Category{Id=8, Name="Tivi"},
                new Category{Id=9, Name="Quạt điện"},
                new Category{Id=10, Name="Lò sưởi"},
            };
        }
    }
}