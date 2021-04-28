using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models
{
   public class MovieDetail
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string MovieDescription { get; set; }


        public MovieGenre Genre { get; set; }

        public MaturityRating MaturityRating { get; set; }

        public double Rating { get; set; }

        public bool WouldWatchAgain { get; set; }

        public string Note { get; set; }
        public int FavoriteID { get; set; }
        public bool IsFavorite { get; set; }

        [Display(Name = "Created")]

        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
