using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Range(0,10)]
        public Nullable<int> Score { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public string MovieTitle { get; set; }
    }
}
