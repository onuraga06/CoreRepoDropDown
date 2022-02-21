using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Models.Entity
{
    public class MovieCategoryModel
    {
       public MovieCategory movieCategory { get; set; }
        public List<MovieCategory> categorieslist { get; set; }
        public Movie movie { get; set; }
        public List<Movie> movielist { get; set; }
        public IQueryable<SelectListItem> selectListItems { get; set; }
       
    }
}
