using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminMovieShop.Models;
using DomainModel;
using MovieShopGateway;

namespace AdminMovieShop.Controllers
{
    public class MoviesController : Controller
    {
        Facade facade = new Facade();
        // GET: Movies
        public ActionResult Index()
        {
            return View(facade.GetMovieGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                Genres = facade.GetGenreGateway().ReadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.Genre = facade.GetGenreGateway().ReadById(movie.Genre.Id);
            facade.GetMovieGateway().Add(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int movieId)
        {
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                Movie = facade.GetMovieGateway().ReadById(movieId),
                Genres = facade.GetGenreGateway().ReadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            facade.GetMovieGateway().Update(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var movie = facade.GetMovieGateway().ReadById(Id);
            return System.Web.UI.WebControls.View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            facade.GetMovieGateway().Remove(movie);
            return Redirect("Index");
        }
    }
}