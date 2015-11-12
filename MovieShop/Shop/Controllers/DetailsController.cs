using MoviesShopProxy;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class DetailsController : Controller
    {
        Facade facade = new Facade();

        // GET: Details
        [HttpGet]
        public ActionResult Index(int id)
        {
            var currencyConverter = new CurrencyConverter(Session["Currency"].ToString());
            var movie = facade.GetMovieRepository().ReadById(id);
            movie.Price = currencyConverter.Convert(movie.Price);
            return View(movie);
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int movieId)
        {
            var movie = facade.GetMovieRepository().ReadById(movieId);

            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Movie>();
            }
            ((List<Movie>)Session["Cart"]).Add(movie);

            return RedirectToAction("Index", "Home");
        }

    }
}