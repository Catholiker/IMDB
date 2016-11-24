using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using MyMovies.BusinessObject;

namespace MyMovies.DataAccess
{
    public class MovieDA : BaseDA
    {
        public bool Insert(Movie movie)
        {
            bool result = false;
            try
            {
                int id = 1;
                if (xmlMoviedoc.Descendants("Movie").Count() != 0)
                    id = xmlMoviedoc.Descendants("Movie").Max(x => (int)x.Element("id")) + 1;
                XElement movieX = new XElement("Movie",
                       new XElement("id", id),
                       new XElement("title", movie.title),
                       new XElement("imageSrc", movie.imageSrc),
                       new XElement("seen", movie.seen)
                       );
                xmlMoviedoc.Root.Add(movieX);
                xmlMoviedoc.Save(xmlMoviePath);
                result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public Movie Get(int id)
        {
            Movie movie = new Movie();
            try
            {
                XElement movieX = xmlMoviedoc.Descendants("Movie").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(id));
                movie = GetDetailFromXElement(movieX);
            }
            catch (Exception)
            {
            }

            return movie;
        }

        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                List<XElement> movieX = xmlMoviedoc.Descendants("Movie").ToList();
                if (movieX != null)
                    movieX.ForEach(c => movies.Add(GetDetailFromXElement(c)));
            }
            catch (Exception)
            {
            }

            return movies;
        }

        public bool Update(Movie movie)
        {
            bool result = false;
            try
            {
                XElement movieX = xmlMoviedoc.Descendants("Movie").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(movie.id));
                XElement updatedMovie = FillXElementFromEntity(movieX, movie);
                xmlMoviedoc.Save(xmlMoviePath);
                result = true;
            }
            catch (Exception)
            {
            }


            return result;
        }

        public bool UpdateSeen(int Id)
        {
            bool result = false;
            try
            {
                XElement movieX = xmlMoviedoc.Descendants("Movie").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(Id));
                movieX.Element("seen").Value = Convert.ToString(true);
                xmlMoviedoc.Save(xmlMoviePath);
                result = true;
            }
            catch (Exception)
            {
            }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                XElement movieX = xmlMoviedoc.Descendants("Movie").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(id));
                if (movieX != null)
                {
                    movieX.Remove();
                    xmlMoviedoc.Save(xmlMoviePath);
                    ReviewDA reviewDA = new ReviewDA();
                    Review review = reviewDA.GetByMovieId(id);
                    if (review.id != 0)
                        reviewDA.Delete(review);
                }
                result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public Movie GetDetailFromXElement(XElement movieX)
        {
            Movie movie = new Movie();
            if (movieX == null)
                return movie;
            movie.id = Convert.ToInt32(movieX.Element("id").Value);
            movie.title = movieX.Element("title").Value;
            if (movieX.Element("imageSrc").Value.Contains("MovieImages"))
            {
                movie.imageSrc = movieX.Element("imageSrc").Value;
            }
            else
            {
                movie.imageSrc = "\\..\\" + MovieImages + "\\" + movieX.Element("imageSrc").Value;
            }

            movie.seen = Convert.ToBoolean(movieX.Element("seen").Value);

            return movie;
        }

        public XElement FillXElementFromEntity(XElement movieX, Movie movie)
        {
            movieX.Element("id").Value = Convert.ToString(movie.id);
            movieX.Element("title").Value = movie.title;
            movieX.Element("imageSrc").Value = movie.imageSrc;
            movieX.Element("seen").Value = Convert.ToString(movie.seen);

            return movieX;
        }
    }
}
