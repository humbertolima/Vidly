using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre field required")]
        [Display(Name= "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Date added required")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Required(ErrorMessage = "Realese date required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "Number in stock is required")]
        public byte NumberInStock { get; set; }


        [Display(Name = "Number Available")]
        [Required(ErrorMessage = "Number available is required")]
        public byte NumberAvailable { get; set; }

    }
}