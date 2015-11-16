using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System.Collections.Generic;
using System.Linq;
using MovieShopDAL.Repository.iRepository;
using System;

namespace MovieShopDAL.Repository
{

    public class MovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> IRepository<Movie>.ReadAll()
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
        public Movie Add(Movie movie)
        {
            using (var ctx = new MovieShopContext())
            {
                // create queries, call attack to attack a already existing genre in the DB on the movie to the movie, this
                //way we prevent it from adding the same genre twice.
                ctx.Movies.Attach(movie);
                var movieToReturn = ctx.Movies.Add(movie);
                // execute changes
                ctx.SaveChanges();
                return movieToReturn;
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

        public Movie Update(Movie movie)
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
                    return movieToUpdate;
                }
                return movie;
            }
        }
    }
}