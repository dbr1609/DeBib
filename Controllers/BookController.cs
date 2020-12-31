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
        private IBookRepository bookrepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookrepository = bookRepository;
        }
        
        public IActionResult Index()
        {
            var books = this.bookrepository.GetAll();
            BookListViewModel bookListViewModel = new BookListViewModel
            {
                Books = books
            };
        return View(bookListViewModel);
        }
    }
}
