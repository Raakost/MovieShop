using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Context
{
    public class MovieShopContext : DbContext
    {
        public MovieShopContext() : base("MovieShop")
        {
            Database.SetInitializer(new MovieShopDBInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
