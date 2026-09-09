using Microsoft.AspNetCore.Mvc;
using Lmq_lab3.Models;

namespace Lmq_lab3.ViewComponents
{
    public class BookViewComponent : ViewComponent   // kế thừa ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();  // tự lấy dữ liệu, không cần ai đưa vào
            return View(books);              // trả dữ liệu ra view riêng của nó
        }
    }
}