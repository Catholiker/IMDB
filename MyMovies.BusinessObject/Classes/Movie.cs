using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.BusinessObject
{
   public class Movie
   {
       public int id { get; set; }
       public string title { get; set; }
       public string imageSrc { get; set; }
       public bool seen { get; set; }
   }
}
