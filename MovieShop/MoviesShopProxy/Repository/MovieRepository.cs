using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MoviesShopProxy.Repository
{

    public class MovieRepository
    {

        public List<Movie> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genre").ToList();
            }
        }

        public Movie ReadById(int Id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genre").FirstOrDefault(x => x.Id == Id);
            }
        }
        public void Add(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                // create queries
                ctx.Movies.Add(movie);
                // execute changes
                ctx.SaveChanges();
            }
        }

        public void Remove(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                var movieToDelete = ctx.Movies.FirstOrDefault(x => x.Id == movie.Id);
                ctx.Movies.Remove(movieToDelete);
                ctx.SaveChanges();
            }
        }

        public void Update(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                var movieToUpdate = ctx.Movies.FirstOrDefault(x => x.Id == movie.Id);
                if (movieToUpdate != null)
                {
                    movieToUpdate.Title = movie.Title;
                    movieToUpdate.Price = movie.Price;
                    movieToUpdate.Year = movie.Year;
                    movieToUpdate.PicturePath = movie.PicturePath;
                    movieToUpdate.TrailerURL = movie.TrailerURL;
                    movieToUpdate.Genre = ctx.Genres.FirstOrDefault(x => x.Id == movie.Genre.Id);
                    ctx.SaveChanges();
                }
            }
        }

    }
}