using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Data
{
    public class Favorite
    {
        
            [Key]
            public int FavId { get; set; }
            [ForeignKey(nameof(Movie))]
            public int MovieId { get; set; }
            public virtual Movie Movie { get; set; }
        
    }
}
