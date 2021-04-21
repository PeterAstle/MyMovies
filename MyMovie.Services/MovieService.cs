using MyMovies.Data;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            var entity = new Movie()
            {
                OwnerId = _userId,
                MovieTitle = model.MovieTitle,
                MovieDescription = model.MovieDescription,
                Genre = model.Genre,
                MaturityRating = model.MaturityRating,
                Rating = model.Rating,
                WouldWatchAgain = model.WouldWatchAgain,
                MovieNote = model.Note,
                IsFavorite = model.IsFavorite,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movie.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
