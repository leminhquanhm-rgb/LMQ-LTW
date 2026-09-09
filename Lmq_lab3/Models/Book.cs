using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lmq_lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book(){ Id = 1, Title = "Chí Phèo", AuthorId = 1, GenreId = 1, Image = "/images/products/b1.jpg", Price = 500000, Sumary = "", TotalPage = 250 },
                new Book(){ Id = 2, Title = "Lão Hạc", AuthorId = 1, GenreId = 1, Image = "/images/products/b2.jpg", Price = 700000, Sumary = "", TotalPage = 400 },
                new Book(){ Id = 4, Title = "Dế Mèn Phiêu lưu ký", AuthorId = 3, GenreId = 1, Image = "/images/products/b3.jpg", Price = 550000, Sumary = "", TotalPage = 180 },
                new Book(){ Id = 6, Title = "Đường Xưa Mây Trắng", AuthorId = 4, GenreId = 3, Image = "/images/products/b4.jpg", Price = 850000, Sumary = "", TotalPage = 320 }
            };
            return books;
        }

        public Book GetBookById(int id)
        {
            return this.GetBookList().FirstOrDefault(b => b.Id == id);
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1", Text="Nam Cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Tô Hoài"},
            new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="1", Text="Truyện tranh"},
            new SelectListItem{Value="2", Text="Văn học đương đại"},
            new SelectListItem{Value="3", Text="Phật học phổ thông"},
            new SelectListItem{Value="4", Text="Truyện cười"}
        };
    }
}