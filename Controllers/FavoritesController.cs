using DeBib.Models;
using DeBib.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.Controllers
{
    public class FavoritesController : Controller
    {
        public static int pageSize = 5;
        private readonly IBookRepository bookRepository;
        public FavoritesController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Index([FromQuery] int page = 1, [FromQuery] Sortfield sort = Sortfield.PublicationYear, [FromQuery] SortDirection sortDirection = SortDirection.ASC)
        {
            var favorites = GetFavoritesFromSession().Values.ToList<FavoriteLines>();
            switch (sort)
            {
                case Sortfield.ISBN:
                    favorites = (sortDirection == SortDirection.ASC) ? favorites.OrderBy(favorites => favorites.Book.ISBN).ToList() : favorites.OrderByDescending(favorites => favorites.Book.ISBN).ToList();
                    break;
                case Sortfield.Title:
                    favorites = (sortDirection == SortDirection.ASC) ? favorites.OrderBy(favorites => favorites.Book.Title).ToList() : favorites.OrderByDescending(favorites => favorites.Book.Title).ToList();
                    break;
                case Sortfield.Author:
                    favorites = (sortDirection == SortDirection.ASC) ? favorites.OrderBy(favorites => favorites.Book.Author).ToList() : favorites.OrderByDescending(favorites => favorites.Book.Author).ToList();
                    break;
                case Sortfield.PublicationYear:
                    favorites = (sortDirection == SortDirection.ASC) ? favorites.OrderBy(favorites => favorites.Book.PublicationYear).ToList() : favorites.OrderByDescending(favorites => favorites.Book.PublicationYear).ToList();
                    break;
                case Sortfield.Type:
                    favorites = (sortDirection == SortDirection.ASC) ? favorites.OrderBy(favorites => favorites.Book.Type).ToList() : favorites.OrderByDescending(favorites => favorites.Book.Type).ToList();
                    break;
                default:
                    break;
            }
            var favoriteViewModel = new FavoritesViewModel
            {
                FavoriteBooks = favorites,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)favorites.Count() / pageSize),
                Sortfield = sort,
                SortDirection = sortDirection
            };
            return View(favoriteViewModel);
        }
        public IActionResult Add(int id)
        {
            var book = bookRepository.Get(id);
            Dictionary<int, FavoriteLines> favorites = GetFavoritesFromSession();
            favorites[id] = favorites.GetValueOrDefault(id, new FavoriteLines { Book = book });
            SaveFavorites(favorites);
            return RedirectToAction("Index", "Book");
        }
        public IActionResult Remove(int id)
        {
            Dictionary<int, FavoriteLines> favorites = GetFavoritesFromSession();
            favorites.Remove(id);
            SaveFavorites(favorites);
            return RedirectToAction("Index", "Favorites");
        }
        private void SaveFavorites(Dictionary<int, FavoriteLines> favorites)
        {
            HttpContext.Session.SetString("Favorites", JsonConvert.SerializeObject(favorites));
        }
        private Dictionary<int, FavoriteLines> GetFavoritesFromSession()
        {
            string sessionString = HttpContext.Session.GetString("Favorites");
            if (sessionString != null)
            {
                return JsonConvert.DeserializeObject<Dictionary<int, FavoriteLines>>(sessionString);
            }
            return new Dictionary<int, FavoriteLines>();
        }
    }
}
