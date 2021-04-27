using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models.FavoriteModels
{
    public class FavouriteDetail
    {
        [Key]
        public int FavouriteID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public int MovieID { get; set; }
        [Required]
        public string MovieTitle { get; set; }

        public virtual List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
