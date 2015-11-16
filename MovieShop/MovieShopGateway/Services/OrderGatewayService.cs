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
    public class OrderGatewayService : IGatewayService<Order>
    {
        public Order Add(Order model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:14718/api/order/", model).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public void Delete(Order model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:14718/api/order/" + model.Id).Result;
            }
        }

        public IEnumerable<Order> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/order/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }

        public Order ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/order/" + id).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public Order Update(Order model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:14718/api/order/" + model.Id, model).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }
    }
}
