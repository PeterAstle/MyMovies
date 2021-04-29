using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models
{
   public class MovieEdit
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string MovieDescription { get; set; }


        public MovieGenre Genre { get; set; }

        public string Note { get; set; }

        public bool IsFavorite { get; set; }

        public int Rating { get; set; }

        public bool WouldWatchAgain { get; set; }

        public MaturityRating MaturityRating { get; set; }

    }
}
