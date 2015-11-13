
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopGateway.Services
{
    public class MovieGatewayService
    {
        public IEnumerable<Movie> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:6191/api/movie/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            }
        }

        public Movie Add(Movie movie)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:6191/api/movie/", movie).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }

    }
}
