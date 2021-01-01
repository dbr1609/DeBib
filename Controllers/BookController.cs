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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel bookCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    ISBN = bookCreateViewModel.ISBN,
                    Title = bookCreateViewModel.Title,
                    Author = bookCreateViewModel.Author,
                    PublicationYear = bookCreateViewModel.PublicationYear,
                    Type = bookCreateViewModel.Type
                };
                this.bookRepository.Create(book);
                TempData["Message"] = $"{book.Title} was added succesfully";
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            var book = this.bookRepository.Get(id);
            if (book != null)
            {
                BookUpdateViewModel bookUpdateViewModel = new BookUpdateViewModel
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear,
                    Type = book.Type
                };
                return View(bookUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Update(int id, BookUpdateViewModel bookUpdateViewModel)
        {
            var book = this.bookRepository.Get(id);
            if (book != null)
            {
                if (ModelState.IsValid)
                {
                    book.ISBN = bookUpdateViewModel.ISBN;
                    book.Title = bookUpdateViewModel.Title;
                    book.Author = bookUpdateViewModel.Author;
                    book.PublicationYear = bookUpdateViewModel.PublicationYear;
                    book.Type = bookUpdateViewModel.Type;
                    this.bookRepository.Update(book);
                    TempData["Message"] = $"{book.Title} was succesfully updated!";
                    return RedirectToAction(nameof(Index), "Book");
                }
                else
                {
                    return View(bookUpdateViewModel);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
