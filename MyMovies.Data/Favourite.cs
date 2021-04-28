using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Data
{
    public class Favourite
    {

        [Key]
        public int FavouriteID { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public bool IsFavorite { get; set; }
        public Guid OwnerID { get; set; }
    }
}
