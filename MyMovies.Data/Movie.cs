using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Data
{
        public enum MovieGenre
        {
            Horror, RomCom, SciFi, Documentary, Action, Comedy, Drama
        }
        public enum MaturityRating
        {
            G, PG, PG13, R, NC17
        }

    public class Movie
    {

        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public string MovieDescription { get; set; }

       
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        [Display(Name = "Rating 1-10, value of 0 will not create a rating.")]

        public int Rating { get; set; }

        [Required]
        public MovieGenre Genre { get; set; }

        public string Note { get; set; }

        [Required]
        public bool WouldWatchAgain { get; set; }

        [Required]

        public MaturityRating MaturityRating { get; set; }

        public virtual List<Favourite> FavList { get; set; }

        
        public bool IsFavorite { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }




    }

}
