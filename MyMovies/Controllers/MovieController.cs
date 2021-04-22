using Microsoft.AspNet.Identity;
using MyMovie.Services;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMovies.Controllers
{
    [Authorize]
    public class MovieController : ApiController
    {
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var movieService = new MovieService(userId);

            return movieService;
        }

        public IHttpActionResult Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();

            if (!service.CreateMovie(movie))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get()
        {
            MovieService movieService = CreateMovieService();

            var movies = movieService.GetMovies();

            return Ok(movies);

        }

        public IHttpActionResult Get(int id)
        {
            MovieService movieService = CreateMovieService();

            var movie = movieService.GetMovieById(id);
            return Ok(movie);
        }

        public IHttpActionResult Get(string title)
        {
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetMovieByTitle(title);
            return Ok(movie);
        }

        public IHttpActionResult Put(MovieEdit movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();

            if (!service.UpdateMovie(movie))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
