using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminMovieShop.Models
{
    public class MoviesViewModel
    {
        public MoviesViewModel() {
            Genres = new List<Genre>();
        }
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
    }
}