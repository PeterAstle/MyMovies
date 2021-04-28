using MyMovies.Data;
using MyMovies.Models;
using MyMovies.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovies

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
            var entity = new Movie
            {
                OwnerId = _userId,
                MovieTitle = model.MovieTitle,
                MovieDescription = model.MovieDescription,
                Rating = model.Rating,
                Genre = model.Genre,
                Note = model.Note,
                WouldWatchAgain = model.WouldWatchAgain,
                MaturityRating = model.MaturityRating,
                IsFavorite = model.IsFavorite,
                CreatedUtc = DateTime.Now
            };

            

            using (var ctx = new ApplicationDbContext())
            {


                entity.Ratings.Add(entity.Score);
                ctx.Movie.Add(entity);

                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<MovieList> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Movie
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new MovieList
                        {
                            MovieId = e.MovieId,
                            MovieTitle = e.MovieTitle,
                            MovieDescription = e.MovieDescription
                        }
                     );

                return query.ToArray();
            }
        }

        public MovieDetail GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movie
                    .Single(e => e.MovieId == id && e.OwnerId == _userId);

                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        MovieTitle = entity.MovieTitle,
                        MovieDescription = entity.MovieDescription,
                        Genre = entity.Genre,
                        MaturityRating = entity.MaturityRating,
                        Rating = entity.Rating,
                        WouldWatchAgain = entity.WouldWatchAgain,
                        Note = entity.Note,
                        IsFavorite = entity.IsFavorite,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }



        }

        public MovieDetail GetMovieByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movie
                    .Single(e => e.MovieTitle.ToLower() == title.ToLower() && e.OwnerId == _userId);

                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        MovieTitle = entity.MovieTitle,
                        MovieDescription = entity.MovieDescription,
                        Genre = entity.Genre,
                        MaturityRating = entity.MaturityRating,
                        Rating = entity.Rating,
                        WouldWatchAgain = entity.WouldWatchAgain,
                        Note = entity.Note,
                        IsFavorite = entity.IsFavorite,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }


        }


        //public bool UpdateMovie(MovieEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {



        //    }
        //}

        public bool DeleteMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movie
                    .Single(e => e.MovieId == id && e.OwnerId == _userId);

                ctx.Movie.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovieByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Movie
                    .Single(e => e.MovieTitle == title && e.OwnerId == _userId);

                ctx.Movie.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
