using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoviesShopProxy;
using MovieShopDAL.DomainModel;

namespace RestMovieShop.Controllers
{
    public class MovieController : ApiController
    {
        public IEnumerable<Movie> ReadAllMovies()
        {
            return new Facade().GetMovieRepository().ReadAll();
        } 
    }
}
