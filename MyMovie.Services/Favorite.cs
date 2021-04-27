using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie.Services
{
    public class Favorite
    {
        private readonly Guid _userID;

        public FavouriteService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateFavourite(FavouriteCreate favourite)
        {
            var target =
                new Favourite()
                {
                    Check = favourite.Check,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favourites.Add(target);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FavouriteListItem> GetFavourites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Favourites
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new FavouriteListItem
                            {
                                MovieTitle = e.MovieTitle,
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
                    .Favourites
                    .Single(e => e.FavouriteID == id && e.OwnerID == _userID);
                return
                    new FavouriteDetail
                    {
                        FavouriteID = target.FavouriteID,
                        MovieTitle = target.MovieTitle,
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
                        .Favourites
                        .Single(e => e.FavouriteID == favouriteID && e.OwnerID == _userID);
                ctx.Favourites.Remove(target);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
