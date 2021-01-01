using DeBib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.ViewModels
{
    public class BookCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Je moet verplicht een ISBN nummer opgeven.")]
        [Display(Name = "ISBN nummer")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Je moet verplicht een titel opgeven.")]
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Je moet verplicht een auteur opgeven.")]
        [Display(Name = "Auteur")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Je moet verplicht een publicatiejaar opgeven.")]
        [Range(1900, 2021, ErrorMessage = "Waarde moet tussen 1900 en 2021 liggen")]
        [Display(Name = "Publicatie jaar")]
        public int PublicationYear { get; set; }
        public BookType Type { get; set; }

    }
}
