using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Name field required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre field required")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Realese date required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "Number in stock is required")]
        public byte? NumberInStock { get; set; }

        public string Title => (Id != 0) ? "Edit Movie" : "New Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}