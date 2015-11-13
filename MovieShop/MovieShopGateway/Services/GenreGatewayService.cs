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
    public class GenreGatewayService : IGatewayService<Genre>
    {
        public Genre Add(Genre model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:14718/api/genre/", model).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public void Delete(Genre model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:14718/api/genre/" + model.Id).Result;
            }
        }

        public IEnumerable<Genre> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/genre/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            }
        }

        public Genre ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/genre/" + id).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public Genre Update(Genre model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:14718/api/genre/" + model.Id, model).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }
    }
}
