using MoviesShopProxy;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminMovieShop.Controllers
{
    public class GenreController : Controller
    {
        Facade facade = new Facade();
        // GET: Genre
        public ActionResult Index()
        {
            return RedirectToAction("Index", "MoviesController");
        }

        [HttpGet]
        public ActionResult Create(string error)
        {
            ViewBag.GenreError = error;
            return View(facade.GetGenreRepository().ReadAll());
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            facade.GetGenreRepository().Add(genre);
            return Redirect("Create");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try {
                facade.GetGenreRepository().Remove(facade.GetGenreRepository().ReadById(Id));
            } catch(Exception ex) { return RedirectToAction("Create", "Genre", new { error = ex.Message }); }
            return RedirectToAction("Create", "Genre");
        }
    }
}