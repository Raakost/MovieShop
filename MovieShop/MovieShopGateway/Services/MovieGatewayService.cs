
using DomainModel;
using MovieShopGateway.Services.IGatewayService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopGateway.Services
{
    public class MovieGatewayService : IGatewayService<Movie>
    {
        public IEnumerable<Movie> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/movie/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            }
        }

        public Movie Add(Movie movie)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:14718/api/movie/", movie).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }

        public Movie ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/movie/" + id).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }

        public Movie Update(Movie model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:14718/api/movie/" + model.Id, model).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }

        public void Delete(Movie model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:14718/api/movie/" + model.Id).Result;
            }
        }
    }
}
