using MovieShopDAL.DomainModel;
using System;
using System.Data.Entity;

namespace MovieShopDAL.Context
{
    public class MovieShopDBInitializer : DropCreateDatabaseAlways<MovieShopContext>
    {

        protected override void Seed(MovieShopContext context)
        {
            var genre1 = new Genre() { Id = 1, Name = "Drama" };
            var genre2 = new Genre() { Id = 2, Name = "Crime" };
            var genre3 = new Genre() { Id = 3, Name = "Action" };
            var genre4 = new Genre() { Id = 4, Name = "Biography" };
            var genre5 = new Genre() { Id = 4, Name = "Music" };

            context.Genres.Add(genre1);
            context.Genres.Add(genre2);
            context.Genres.Add(genre3);
            context.Genres.Add(genre4);
            context.Genres.Add(genre5);

            context.Movies.Add(new Movie()
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Year = new DateTime(1994, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/shawshankRedemption.jpg",
                TrailerURL = "https://www.youtube.com/embed/NmzuHjWmXOc",
                Genre = genre1
            });
            context.Movies.Add(new Movie()
            {
                Id = 2,
                Title = "The Godfather",
                Year = new DateTime(1972, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/godfather.jpg",
                TrailerURL = "https://www.youtube.com/embed/w0VGcWHkNeA",
                Genre = genre2
            });
            context.Movies.Add(new Movie()
            {
                Id = 3,
                Title = "The Lego Movie",
                Year = new DateTime(2014, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/lego.jpg",
                TrailerURL = "https://www.youtube.com/embed/fZ_JOBCLF-I",
                Genre = genre3
            });
            context.Movies.Add(new Movie()
            {
                Id = 4,
                Title = "The Godfather: part II",
                Year = new DateTime(1974, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/godfather2.jpg",
                TrailerURL = "https://www.youtube.com/embed/8PyZCU2vpi8",
                Genre = genre2
            });
            context.Movies.Add(new Movie()
            {
                Id = 5,
                Title = "The Dark Knight",
                Year = new DateTime(2008, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/darkKnight.jpg",
                TrailerURL = "https://www.youtube.com/embed/EXeTwQWrcwY",
                Genre = genre3
            });
            context.Movies.Add(new Movie()
            {
                Id = 6,
                Title = "Pulp Fiction",
                Year = new DateTime(1994, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/pulpFiction.jpg",
                TrailerURL = "https://www.youtube.com/embed/ewlwcEBTvcg",
                Genre = genre2
            });
            context.Movies.Add(new Movie()
            {
                Id = 7,
                Title = "Intouchables",
                Year = new DateTime(2011, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/intouchables.jpg",
                TrailerURL = "https://www.youtube.com/embed/34WIbmXkewU",
                Genre = genre4
            });
            context.Movies.Add(new Movie()
            {
                Id = 8,
                Title = "Whiplash",
                Year = new DateTime(2014, 1, 1),
                Price = 100,
                PicturePath = "/Content/Pictures/whiplash.jpg",
                TrailerURL = "https://www.youtube.com/embed/7d_jQycdQGo",
                Genre = genre5
            });

            //Add customers to DB.
            context.Customers.Add(new Customer()
            {
                Id = 1,
                Firstname = "Finn",
                Lastname = "Jensen",
                StreetName = "Storegade",
                StreetNumber = "54",
                Zipcode = 6700,
                Country = "Danmark",
                Email = "finn@mail.com"
            });
            context.Customers.Add(new Customer()
            {
                Id = 2,
                Firstname = "Jakob",
                Lastname = "Jensen",
                StreetName = "Lillebælts vej",
                StreetNumber = "7",
                Zipcode = 6700,
                Country = "Danmark",
                Email = "jacob@mail.com"
            });

            base.Seed(context);
        }
    }
}
