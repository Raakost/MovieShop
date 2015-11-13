using MovieShopGateway;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        Facade facade = new Facade();

        [HttpGet]
        public ActionResult Index(int? genreId)
        {
            var movies = facade.GetMovieGateway().ReadAll();

            if (genreId.HasValue)
            {
                movies = movies.Where(x => x.Genre.Id == genreId.Value).ToList();
            }
            return View(movies);
        }

        public ActionResult GenreDropDown()
        {
            var genres = facade.GetGenreGateway().ReadAll();

            return PartialView(genres);
        }

        public ActionResult CurrencyDropDown()
        {
            var converter = new CurrencyConverter(Session["Currency"].ToString());

            return PartialView(converter.Currencies);
        }

        public ActionResult ChooseCurrency(string currency)
        {
            Session["Currency"] = currency;
            return new RedirectResult(Request.UrlReferrer.ToString());
        }

    }
}