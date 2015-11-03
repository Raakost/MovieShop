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
    }
}
