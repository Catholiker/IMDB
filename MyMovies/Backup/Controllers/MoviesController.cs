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
    public class MoviesController : ApiController
    {
        // GET api/Movies
        public IEnumerable<Movie> Get()
        {
            List<Movie> movies = new MovieDA().GetAll();
            //string moviesSerialized = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(movies);

            return movies;
        }

        // GET api/Movies/5
        public Movie Get(int id)
        {
           Movie movie = new MovieDA().Get(id);
            return movie;
        }

        // POST api/Movies
        public bool Post([FromBody]Movie movie)
        {
            bool result = new MovieDA().Insert(movie);
            return result;
        }

        // PUT api/Movies/5
        public bool Put(int id, [FromBody]Movie movie)
        {
            bool result = new MovieDA().Update(movie);
            return result;
        }

        // DELETE api/Movies/5
        public bool Delete(int id)
        {
            bool result = new MovieDA().Delete(id);
            return result;
        }

    }
}