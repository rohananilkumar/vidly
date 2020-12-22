using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Display(Name="Number Available")]
        public int NumberAvailable { get; set; }
    }
}