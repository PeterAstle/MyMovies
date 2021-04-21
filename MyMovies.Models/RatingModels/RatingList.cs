using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models.RatingModels
{
   public class RatingList
    {
        public int RatingId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public double Score { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
