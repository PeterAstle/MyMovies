using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models
{
   public class MovieCreate
    {
        public int MovieId { get; set; }

        [Required, MaxLength(25, ErrorMessage ="Titles cannot exceed 25 characters."), MinLength(2, ErrorMessage ="The title will need to be at least 2 characters.")]
        public string MovieTitle { get; set; }

        [Required]
        public string MovieDescription { get; set; }


        [Required]
        public MovieGenre Genre { get; set; }

        [Required]
        public MaturityRating MaturityRating { get; set; }

        [Range(0, 10)]
        [Display(Name = "Rating 1-10, value of 0 will not create a rating.")]

        public int Rating { get; set; }

        [Required]
        public bool WouldWatchAgain { get; set; }

        [MaxLength(500, ErrorMessage ="Please limit your note to 500 characters or less.")]
        public string Note { get; set; }

        public bool IsFavorite { get; set; }

    }
}
