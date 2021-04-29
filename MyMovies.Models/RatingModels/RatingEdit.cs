﻿using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Models.RatingModels
{
    public class RatingEdit
    {
        [Required]
        public int RatingId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public Nullable<int> Score { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
