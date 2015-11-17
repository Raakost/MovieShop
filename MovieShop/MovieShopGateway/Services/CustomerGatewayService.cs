using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using MovieShopGateway.Services.IGatewayService;
using System.Net.Http;

namespace MovieShopGateway.Services
{
    public class CustomerGatewayService : IGatewayService<Customer>
    {
        public Customer Add(Customer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:14718/api/customer/", model).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

        public void Delete(Customer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:14718/api/customer/" + model.Id).Result;
            }
        }

        public IEnumerable<Customer> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/customer/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            }
        }

        public Customer ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/customer/" + id).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

        public Customer Update(Customer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:14718/api/customer/" + model.Id, model).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

        public Customer ReadByEmail(string email)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:14718/api/customer?email=" + email).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }
    }
}
