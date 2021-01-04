using DeBib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.ViewModels
{
    public class FavoritesViewModel
    {
        public IEnumerable<FavoriteLines> FavoriteBooks { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public SortDirection SortDirection { get; set; }
        public Sortfield Sortfield { get; set; }
    }
}
