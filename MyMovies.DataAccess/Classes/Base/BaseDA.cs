using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MyMovies.DataAccess
{
    public class BaseDA
    {
        public static string BasePath = System.Configuration.ConfigurationManager.AppSettings["basePath"];
        public static string MovieImages = System.Configuration.ConfigurationManager.AppSettings["MovieImages"];
        public static string xmlMoviePath = BasePath + System.Configuration.ConfigurationManager.AppSettings["MoviesXmlPath"];
        public static XDocument xmlMoviedoc = XDocument.Load(xmlMoviePath);
        public static string xmlReviewPath = BasePath + System.Configuration.ConfigurationManager.AppSettings["ReviewXmlPath"];
        public static XDocument xmlReviewdoc = XDocument.Load(xmlReviewPath);
    }
}
