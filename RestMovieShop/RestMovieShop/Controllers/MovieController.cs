using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShopDAL;
using MovieShopDAL.DomainModel;

namespace RestMovieShop.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public IEnumerable<Movie> ReadAllMovies()
        {
            return new Facade().GetMovieRepository().ReadAll();
        }

        [HttpGet]
        public Movie ReadById(int Id)
        {
            return new Facade().GetMovieRepository().ReadById(Id);
        }

        [HttpDelete]
        public void DeleteMovie(Movie movie)
        {
            new Facade().GetMovieRepository().Remove(movie);
        }
    }
}
