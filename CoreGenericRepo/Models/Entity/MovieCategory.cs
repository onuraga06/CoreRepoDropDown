using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Models.Entity
{
    public class MovieCategory
    {
        public int MovieCategoryID { get; set; }
        public string MovieCategoryName { get; set; }
        public ICollection<Movie> movies { get; set; }
  

    }
}
