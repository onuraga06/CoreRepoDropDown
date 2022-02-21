using CoreGenericRepo.Controllers.Repository;
using CoreGenericRepo.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Controllers
{
    public class MovieController : Controller
    {
        private IBaseRepository<Movie> rep;
        private IBaseRepository<MovieCategory> rep2;
        MovieCategoryModel model = new MovieCategoryModel();
       

        public MovieController(IBaseRepository<Movie> _rep,IBaseRepository<MovieCategory> _rep2)
        {
            rep = _rep;
            rep2 = _rep2;
        }
        public IActionResult Index()
        {
            model.movielist = rep.GetList();
            
            return View(model);
        }
        public IActionResult Ekle( )
        {
            model.selectListItems=rep2.GetAllList().Select(x=> new SelectListItem() 
            { 
                Text=x.MovieCategoryName,
                Value=x.MovieCategoryID.ToString()
            
            }   );
            return View(model);
        }
        [HttpPost]
        public IActionResult Ekle(MovieCategoryModel mc)
        {
            if (ModelState.IsValid)
            {
                Movie p = new Movie();
                p.MovieName = mc.movie.MovieName;
                p.Description = mc.movie.Description;
                p.Image = mc.movie.Image;
                p.MovieCategoryID = mc.movie.MovieCategoryID;
                rep.Add(p);
                rep.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Guncel(int id)
        {
            model.movie = rep.Bul(id);
            model.selectListItems = rep2.GetAllList().Select(x => new SelectListItem()
            {
                Text = x.MovieCategoryName,
                Value = x.MovieCategoryID.ToString()
            });
            return View(model);
        }
        [HttpPost]
        public IActionResult Guncel(int id,MovieCategoryModel mc)
        {
            if (ModelState.IsValid)
            {
                Movie m = rep.Bul(id);
                m.MovieName = mc.movie.MovieName;
                m.Description = mc.movie.Description;
                rep.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Sil(int id)
        {
            Movie m = rep.Bul(id);
            rep.Delete(m);
            rep.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Detay(int id)
        {
            model.movie = rep.Bul(id);
            model.movieCategory = rep2.GetAllList().FirstOrDefault(x=> x.MovieCategoryID==model.movie.MovieCategoryID);
            return View(model);

        }
    }
}
