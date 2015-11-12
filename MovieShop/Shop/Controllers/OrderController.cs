using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            //if (Session["Cart"] == null)
            //{
            //    Session["Cart"] = new List<Movie>();
            //}

            //var movies = ((List<Movie>) Session["Cart"]);
            //var currencyConverter = new CurrencyConverter(Session["Currency"].ToString());
            //foreach (var movie in movies)
            //{
            //    movie.Price = currencyConverter.Convert(movie.Price);
            //}
            //return PartialView(movies);


            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Movie>();
            }

            var movies = new List<Movie>();
            var currencyConverter = new CurrencyConverter(Session["Currency"].ToString());
            foreach (var movie in ((List<Movie>)Session["Cart"]))
            {
                movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Price = currencyConverter.Convert(movie.Price),
                    PicturePath = movie.PicturePath
                });
            }
            return PartialView(movies);
        }
    }
}