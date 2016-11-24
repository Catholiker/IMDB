using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using MyMovies.BusinessObject;

namespace MyMovies.DataAccess
{
    public class ReviewDA : BaseDA
    {
        public bool Insert(Review review)
        {
            bool result = false;
            MovieDA movieTask = new MovieDA();
            try
            {
                bool IsMovie = movieTask.Get(review.movieId) != null ? true : false;
                movieTask.UpdateSeen(review.movieId);
                if (IsMovie)
                {
                    XElement reviewX = new XElement("Review",
                           new XElement("id", review.id),
                           new XElement("movieId", review.movieId),
                           new XElement("text", review.text),
                           new XElement("rating", review.rating)
                           );
                    xmlReviewdoc.Root.Add(reviewX);
                    xmlReviewdoc.Save(xmlReviewPath);
                    result = true;
                }
                else
                    result = false;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public Review GetByMovieId(int movieid)
        {
            Review review = new Review();
            try
            {
                int id = 1;
                if (xmlMoviedoc.Descendants("Review").Count() != 0)
                    id = xmlMoviedoc.Descendants("Review").Max(x => (int)x.Element("id")) + 1;
                XElement reviewX = xmlReviewdoc.Descendants("Review").FirstOrDefault(c => c.Element("movieId").Value == Convert.ToString(movieid));
                review = GetDetailFromXElement(reviewX);
                review.id = id;
            }
            catch (Exception)
            {
            }

            return review;
        }

        public List<Review> GetAll()
        {
            List<Review> reviews = new List<Review>();
            try
            {
                List<XElement> reviewX = xmlReviewdoc.Descendants("Review").ToList();
                reviewX.ForEach(c => reviews.Add(GetDetailFromXElement(c)));
            }
            catch (Exception)
            {
            }

            return reviews;
        }

        public bool Update(Review review)
        {
            bool result = false;
            MovieDA movieTask = new MovieDA();
            try
            {
                bool IsMovie = movieTask.Get(review.movieId) != null ? true : false;
                movieTask.UpdateSeen(review.movieId);
                if (IsMovie)
                {
                    XElement reviewX = xmlReviewdoc.Descendants("Review").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(review.id));
                    XElement updatedReview = FillXElementFromEntity(reviewX, review);
                    //xmlReviewdoc.Root.Add(updatedReview);
                    xmlReviewdoc.Save(xmlReviewPath);
                    result = true;
                }
                else
                    result = false;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public bool Delete(Review review)
        {
            bool result = false;
            try
            {
                XElement reviewX = xmlReviewdoc.Descendants("Review").FirstOrDefault(c => c.Element("id").Value == Convert.ToString(review.id));
                if (reviewX != null)
                {
                    reviewX.Remove();
                    xmlReviewdoc.Save(xmlReviewPath);
                }
                result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public Review GetDetailFromXElement(XElement reviewX)
        {
            Review review = new Review();
            if (reviewX == null)
                return review;
            review.id = Convert.ToInt32(reviewX.Element("id").Value);
            review.movieId = Convert.ToInt32(reviewX.Element("movieId").Value);
            review.text = reviewX.Element("text").Value;
            review.rating = Convert.ToInt32(reviewX.Element("rating").Value);

            return review;
        }

        public XElement FillXElementFromEntity(XElement reviewX, Review review)
        {
            reviewX.Element("id").Value = Convert.ToString(review.id);
            reviewX.Element("movieId").Value = Convert.ToString(review.movieId);
            reviewX.Element("text").Value = review.text;
            reviewX.Element("rating").Value = Convert.ToString(review.rating);

            return reviewX;
        }
    }
}
