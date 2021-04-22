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
                    
                    Score = rating.Score,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rating.Add(target);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RatingList> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rating
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RatingList
                                {
                                    MovieTitle = e.MovieTitle,
                                    Score = e.Score,
                                    //CreatedUtc = e.CreatedUtc
                                }
                              );
                return query.ToArray();
            }
        }
        public RatingList GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rating
                        .Single(e => e.RatingId == id && e.OwnerId == _userId);
                return
                    new RatingList
                    {
                        //RatingId = entity.RatingId,
                        //MovieId = entity.MovieId,
                        MovieTitle = entity.MovieTitle,
                        Score = entity.Score,
                        //CreatedUtc = entity.CreatedUtc,
                        //ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateRating(RatingEdit rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rating
                        .Single(e => e.RatingId == rating.RatingId && e.OwnerId == _userId);
                entity.RatingId = rating.RatingId;
                entity.Score = rating.Score;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRating(int ratingId)
        {
                using (var ctx = new ApplicationDbContext())
                {
                var entity =
                    ctx
                        .Rating.Single(e => e.RatingId == ratingId && e.OwnerId == _userId);
                ctx.Rating.Remove(entity);
                return ctx.SaveChanges() == 1;
                }
            
        }
    }
}
