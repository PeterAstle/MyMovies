using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models.FavoriteModels
{
   public class FavouriteList
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public bool Check { get; set; }
    }
}
