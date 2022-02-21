using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Models.Entity
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("MovieCategory")]
        public int MovieCategoryID { get; set; }
        public MovieCategory movieCategory { get; set; }
    }
}
