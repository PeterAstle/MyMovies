﻿using Microsoft.AspNet.Identity;
using MyMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMovies.Controllers
{
    public class RatingController : ApiController
    {
        public IHttpActionResult Get()
        {
            RatingService ratingService = CreateRatingService();
            var ratings = ratingService.GetRatings();
            return Ok(ratings);
        }
        public IHttpActionResult Get(int id)
        {
            RatingService ratingService = CreateRatingService();
            var rating = ratingService.GetRatingById(id);
            return Ok(rating);
        }
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RatingService(userId);
            return ratingService;
        }
    }
    
}
