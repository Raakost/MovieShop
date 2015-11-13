using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.Repository.iRepository;

namespace MovieShopDAL.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        public IEnumerable<Genre> ReadAll()
        {

            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.ToList();
            }
        }

        public Genre ReadById(int Id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.Where(ge => ge.Id == Id).FirstOrDefault();
            }
        }

        public Genre Add(Genre genre)
        {
            using (var ctx = new MovieShopContext())
            {
                // create queries
                var genreToUpdate = ctx.Genres.Add(genre);
                // execute changes
                ctx.SaveChanges();
                return genreToUpdate;
            }
        }

        public void Remove(Genre genre)
        {
            try
            {
                using (var ctx = new MovieShopContext())
                {
                    var genreToDelete = ctx.Genres.FirstOrDefault(x => x.Id == genre.Id);
                    ctx.Genres.Remove(genreToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("This Genre exists in a movie and can not be deleted");
            }
        }

        public Genre Update(Genre genre)
        {
            using (var ctx = new MovieShopContext())
            {
                var genreToUpdate = ctx.Genres.FirstOrDefault(x => x.Id == genre.Id);
                if (genreToUpdate != null)
                {
                    genreToUpdate.Name = genre.Name;
                    ctx.SaveChanges();
                    return genreToUpdate;
                }
                return genre;
            }
        }
    }
}
