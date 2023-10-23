using System.Diagnostics;
using BookstoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreMVC.Controllers;

public class BookstoreController : Controller
{
    private static IList<Book> books = new List<Book>
    {
        new Book
        {
            Id = 1, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PageCount = 224,
            Isbn = "978-0-316-76948-0"
        },
        new Book
        {
            Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PageCount = 336, Isbn = "978-0-06-112008-4"
        },
        new Book { Id = 3, Title = "1984", Author = "George Orwell", PageCount = 328, Isbn = "978-0-452-28423-4" },
        new Book
        {
            Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", PageCount = 279, Isbn = "978-0-486-43667-0"
        },
        new Book
        {
            Id = 5, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PageCount = 180,
            Isbn = "978-0-7432-7356-5"
        }
    };
    
    private readonly ILogger<BookstoreController> _logger;

    public BookstoreController(ILogger<BookstoreController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View(books);
    }

    // GET: FilmController/Details/5
    public ActionResult Details(int id)
    {
        return View(books.FirstOrDefault(book=> book.Id==id));
    }

    // GET: FilmController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FilmController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Book book)
    {

        book.Id = books.Count + 1;
        books.Add(book);
        return RedirectToAction("Index");
    }

    // GET: FilmController/Edit/5
    public ActionResult Edit(int id)
    {
        return View(books.FirstOrDefault(book => book.Id == id));
    }

    // POST: FilmController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Book book)
    {
        Book bookToEdit = books.FirstOrDefault(book => book.Id == id);

        bookToEdit.Title = book.Title;
        bookToEdit.Author = book.Author;
        bookToEdit.Isbn = book.Isbn;

        return RedirectToAction("Index");
    }

    // GET: FilmController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(books.FirstOrDefault(book => book.Id == id));
    }

    // POST: FilmController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Book book, int id)
    {
        Book bookToRemove = books.FirstOrDefault(x => x.Id == id);
        books.Remove(bookToRemove);
        return RedirectToAction("Index");
    }
    

}