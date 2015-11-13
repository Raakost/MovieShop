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
    public class GenreController : ApiController
    {
        [HttpGet]
        public IEnumerable<Genre> ReadAll()
        {
            return new Facade().GetGenreRepository().ReadAll();
        }

        [HttpGet]
        public Genre ReadById(int Id)
        {
            return new Facade().GetGenreRepository().ReadById(Id);
        }

        [HttpPost]
        public Genre AddGenre(Genre genre)
        {
            return new Facade().GetGenreRepository().Add(genre);
        }


        [HttpDelete]
        public void DeleteGenre(int id)
        {
            var genre = new Genre() {Id = id};
            new Facade().GetGenreRepository().Remove(genre);
        }

        [HttpPut]
        public Genre UpdateGenre(Genre genre, int Id)
        {
            genre.Id = Id;
            return new Facade().GetGenreRepository().Update(genre);
        }
    }
}
