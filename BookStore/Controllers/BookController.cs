using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using System.Data.Entity.Infrastructure;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Teacher";
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The comple Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC3 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The comple Manual", "Author Name Book 1", "../Content/Images/tải xuống.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "../Content/Images/tải xuống (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC3", "Author Name Book 3", "../Content/Images/tải xuống (2).jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The comple Manual", "Author Name Book 1", "../Content/Images/tải xuống.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "../Content/Images/tải xuống (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC3", "Author Name Book 3", "../Content/Images/tải xuống (2).jpg"));
            // Edit book
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        //post: book
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook(int id,string Title,string Author,string Image)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The comple Manual", "Author Name Book 1", "../Content/Images/tải xuống.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "../Content/Images/tải xuống (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC3", "Author Name Book 3", "../Content/Images/tải xuống (2).jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image = Image;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "Id, Title, Author, Image")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The comple Manual", "Author Name Book 1", "../Content/Images/tải xuống.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2", "../Content/Images/tải xuống (1).jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC3", "Author Name Book 3", "../Content/Images/tải xuống (2).jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}