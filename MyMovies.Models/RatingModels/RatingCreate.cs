using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovies.Data;

namespace MyMovies.Models.RatingModels
{
    public class RatingCreate
    {   
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public double Score { get; set; }
    }
}
