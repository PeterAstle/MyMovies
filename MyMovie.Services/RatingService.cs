using MyMovies.Data;
using MyMovies.Models.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userid)
        {
            _userId = userid;
        }
        public bool CreateRating(RatingCreate rating)
        {
            var target =
                new Rating()
                {
                    OwnerId = _userId,
                    Score = rating.Score,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rating.Add(target);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
