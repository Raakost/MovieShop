using MovieShopDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.DomainModel;
using MovieShopDAL.Repository.iRepository;

namespace MovieShopDAL
{
    public class Facade
    {
        private GenreRepository genreRepo;
        private CustomerRepository customerRepo;
        private OrderRepository orderRepo;
        private IRepository<Movie> movieRepo;

        public IRepository<Movie> GetMovieRepository()
        {
            if (movieRepo == null)
            {
                movieRepo = new MovieRepository();
            }
            return movieRepo;
        }

        public GenreRepository GetGenreRepository()
        {
            if (genreRepo == null)
            {
                genreRepo = new GenreRepository();
            }
            return genreRepo;
        }

        public CustomerRepository GetCustomerRepository()
        {
            if (customerRepo == null)
            {
                customerRepo = new CustomerRepository();
            }
            return customerRepo;
        }

        public OrderRepository GetOrderRepository()
        {
            if (orderRepo == null)
            {
                orderRepo = new OrderRepository();
            }
            return orderRepo;
        }
    }
}
