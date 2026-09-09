using Microsoft.AspNetCore.Mvc;
using Lmq_lab3.Models;

namespace Lmq_lab3.ViewComponents
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            var books = book.GetBookList();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            return RedirectToAction("Index");
        }

        // ---- Bài 3: trả về PartialView cho jQuery Ajax ----
        public PartialViewResult PopularBook()
        {
            var books = book.GetBookList();
            return PartialView(books);
        }
    }
}