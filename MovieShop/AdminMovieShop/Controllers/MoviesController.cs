using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesShopProxy;
using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using AdminMovieShop.Models;

namespace AdminMovieShop.Controllers
{
    public class MoviesController : Controller
    {
        Facade facade = new Facade();
        // GET: Movies
        public ActionResult Index()
        {
            return View(facade.GetMovieRepository().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                Genres = facade.GetGenreRepository().ReadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.Genre = facade.GetGenreRepository().ReadById(movie.Genre.Id);
            facade.GetMovieRepository().Add(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int movieId)
        {
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                Movie = facade.GetMovieRepository().ReadById(movieId),
                Genres = facade.GetGenreRepository().ReadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            facade.GetMovieRepository().Update(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var movie = facade.GetMovieRepository().ReadById(Id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            facade.GetMovieRepository().Remove(movie);
            return Redirect("Index");
        }
    }
}