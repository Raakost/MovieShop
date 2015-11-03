using MovieShopDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy
{
    public class Facade
    {
        private MovieRepository movieRepo;
        private GenreRepository genreRepo;
        private CustomerRepository customerRepo;
        private OrderRepository orderRepo;

        public MovieRepository GetMovieRepository()
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
