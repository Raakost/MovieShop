using MovieShopGateway;
using System;
using System.Web.Mvc;
using DomainModel;

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
            return View(facade.GetGenreGateway().ReadAll());
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            facade.GetGenreGateway().Add(genre);
            return Redirect("Create");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try {
                facade.GetGenreGateway().Delete(facade.GetGenreGateway().ReadById(Id));
            } catch(Exception ex) { return RedirectToAction("Create", "Genre", new { error = ex.Message }); }
            return RedirectToAction("Create", "Genre");
        }
    }
}