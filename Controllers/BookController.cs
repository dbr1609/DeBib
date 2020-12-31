using DeBib.Models;
using DeBib.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        
        public IActionResult Index()
        {
            var books = this.bookRepository.GetAll();
            BookListViewModel bookListViewModel = new BookListViewModel
            {
                Books = books
            };
        return View(bookListViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Book book = this.bookRepository.Get(Id);
            if (book != null)
            {
                this.bookRepository.Delete(book);
                TempData["Message"] = $"{book.Title} is verwijderd.";
                return RedirectToAction("Index", "Book");
            }
            return NotFound();
        }
    }
}
