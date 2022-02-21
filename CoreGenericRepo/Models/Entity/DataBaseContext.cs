using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Models.Entity
{
    public class DataBaseContext:DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext>options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
    }
}
