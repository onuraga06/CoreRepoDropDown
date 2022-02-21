using CoreGenericRepo.Controllers.Repository;
using CoreGenericRepo.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Controllers
{
    public class MovieCategoryController : Controller
    {
        private IBaseRepository<MovieCategory> rep;
        MovieCategoryModel model = new MovieCategoryModel();
        
        public MovieCategoryController(IBaseRepository<MovieCategory> _rep)
        {
            rep = _rep;
        }
        public IActionResult Index()
        {
            model.categorieslist = rep.GetList();
            return View(model);
        }
        public IActionResult Detay(int id)
        {
            model.movieCategory = rep.Bul(id);
            return View(model);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(MovieCategoryModel mc)
        {
            if (ModelState.IsValid)
            {
                MovieCategory m = new MovieCategory();
                m.MovieCategoryID = mc.movieCategory.MovieCategoryID;
                m.MovieCategoryName = mc.movieCategory.MovieCategoryName;
                rep.Add(m);
                rep.Save();
                return RedirectToAction("Index");

            }
            return View();

        }
        public IActionResult Guncel(int id)
        {
            model.movieCategory = rep.Bul(id);
            return View(model);

        }
        [HttpPost]
        public IActionResult Guncel(int id,MovieCategoryModel category)
        {
            if (ModelState.IsValid)
            {
                MovieCategory m = rep.Bul(id);
                
                m.MovieCategoryName = category.movieCategory.MovieCategoryName;
                rep.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Sil(int id)
        {
            MovieCategory m = rep.Bul(id);
            rep.Delete(m);
            rep.Save();
            return RedirectToAction("Index");
        }
       
    }
}
