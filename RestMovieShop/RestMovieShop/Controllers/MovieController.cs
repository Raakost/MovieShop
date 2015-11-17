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
            var result = new Facade().GetMovieRepository().ReadAll();
            return result;
        }

        [HttpGet]
        public Movie ReadById(int Id)
        {
            return new Facade().GetMovieRepository().ReadById(Id);
        }

        [HttpPost]
        public Movie AddMovie(Movie movie)
        {
            return new Facade().GetMovieRepository().Add(movie);
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = new Movie() {Id = id};
            new Facade().GetMovieRepository().Remove(movie);
        }
        
        [HttpPut]
        public Movie UpdateMovie(int Id, Movie movie)
        {
            movie.Id = Id;
            return new Facade().GetMovieRepository().Update(movie);
        }


    }
}
