using MovieShopGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopGateway
{
    public class Facade
    {
        public MovieGatewayService GetMovieGateway()
        {
            return new MovieGatewayService();
        }

        public GenreGatewayService GetGenreGateway()
        {
            return new GenreGatewayService();
        }

        public CustomerGatewayService GetCustomerGateway()
        {
            return new CustomerGatewayService();
        }

        public OrderGatewayService GetOrderGateway()
        {
            return new OrderGatewayService();
        }

    }
}
