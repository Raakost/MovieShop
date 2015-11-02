using MoviesShopProxy;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        Facade facade = new Facade();

        [HttpGet]
        public ActionResult Index(int? genreId)
        {
            var movies = facade.GetMovieRepository().ReadAll();

            if (genreId.HasValue)
            {
                movies = movies.Where(x => x.Genre.Id == genreId.Value).ToList();
            }
            return View(movies);
        }

        public ActionResult GenreDropDown()
        {
            var genres = facade.GetGenreRepository().ReadAll();

            return PartialView(genres);
        }



    }
}