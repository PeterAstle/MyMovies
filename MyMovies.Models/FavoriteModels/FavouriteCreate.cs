using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models.FavoriteModels
{
    public class FavoriteCreate
    {
        public int MovieID { get; set; }
        public bool Check { get; set; }
    }
}
