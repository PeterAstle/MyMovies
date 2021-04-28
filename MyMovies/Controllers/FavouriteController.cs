using Microsoft.AspNet.Identity;
using MyMovie.Services;
using MyMovies.Models.FavoriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMovies.Controllers
{
    [Authorize]
    public class FavouriteController : ApiController
    {
        private FavouriteServices CreateFavouriteService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var service = new FavouriteServices(user);
            return service;
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] FavoriteCreate favouriteCreate)
        {
            if (favouriteCreate is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateFavouriteService();
            bool success = service.CreateFavourite(favouriteCreate);
            if (!success)
            {
                return InternalServerError();
            }
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var service = CreateFavouriteService();
            var favourite = service.GetFavouriteByID(id);
            if (favourite is null)
            {
                return NotFound();
            }
            return Ok(favourite);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var service = CreateFavouriteService();
            var success = service.DeleteFavourite(id);
            if (!success)
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
