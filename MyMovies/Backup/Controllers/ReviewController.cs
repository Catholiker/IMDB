using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyMovies.BusinessObject;
using MyMovies.DataAccess;

namespace MyMovies.Controllers
{
    public class ReviewController : ApiController
    {
        // GET api/Reviews
        public IEnumerable<string> Get()
        {
            List<string> s = new List<string>();
            //string moviesSerialized = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(movies);

            return s;
        }

        // GET api/Reviews/5
        public Review Get(int id)
        {
            Review review = new ReviewDA().GetByMovieId(id);
            return review;
        }

        // POST api/Review
        public bool Post([FromBody]Review review)
        {
            bool result = false;
            if (review != null)
            {
                Review reviewbo = new ReviewDA().GetByMovieId(review.movieId);
                if (reviewbo.id == 1)
                    result = new ReviewDA().Insert(review);
                else
                    result = new ReviewDA().Update(review);
            }
            return result;
        }

        // PUT api/Reviews/5
        public void Put(int id, [FromBody]Review movie)
        {
            // bool result = new MovieDA().Update(movie);
            // return result;
        }

        // DELETE api/Reviews/5
        public void Delete(int id)
        {
            // bool result = new MovieDA().Delete(id);
            // return result;
        }

    }
}