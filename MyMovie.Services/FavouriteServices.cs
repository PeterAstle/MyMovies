using MyMovies.Data;
using MyMovies.Models;
using MyMovies.Models.FavoriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Services
{
    public class FavouriteServices
    {
        private readonly Guid _userID;

        public FavouriteServices(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateFavourite(FavoriteCreate favourite)
        {
            var target =
                new Favourite()
                {
                    OwnerID = _userID,
                    MovieId = favourite.MovieID,
                    Check = favourite.Check,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favourite.Add(target);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FavouriteList> GetFavourites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Favourite
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new FavouriteList
                            {
                                FavouriteID = e.FavouriteID,
                                MovieId = e.MovieId,
                                MovieTitle = ctx.Movie.Find(e.MovieId).MovieTitle,
                                Check = e.Check
                            }
                    );
                return query.ToArray();
            }
        }
        public FavouriteDetail GetFavouriteByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var target =
                    ctx
                    .Favourite
                    .Single(e => e.FavouriteID == id && e.OwnerID == _userID);
                return
                    new FavouriteDetail
                    {
                        FavouriteID = target.FavouriteID,
                        MovieID = target.MovieId,
                        MovieTitle = ctx.Movie.Find(target.MovieId).MovieTitle,
                        Check = target.Check
                    };
            }
        }
        public bool DeleteFavourite(int favouriteID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var target =
                    ctx
                        .Favourite
                        .Single(e => e.FavouriteID == favouriteID && e.OwnerID == _userID);
                ctx.Favourite.Remove(target);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
