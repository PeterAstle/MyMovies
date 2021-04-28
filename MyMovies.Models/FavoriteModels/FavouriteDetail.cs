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
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public bool Check { get; set; }
    }
}
