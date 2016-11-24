using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.BusinessObject
{
    public class Review
    {
        public int id { get; set; }
        public int movieId { get; set; }
        public string text { get; set; }
        public int rating { get; set; }
    }
}
