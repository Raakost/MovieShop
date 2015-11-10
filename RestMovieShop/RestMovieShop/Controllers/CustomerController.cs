using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShopDAL;
using MovieShopDAL.DomainModel;

namespace RestMovieShop.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IEnumerable<Customer> ReadAllCustomer()
        {
            return new Facade().GetCustomerRepository().ReadAll();
        }

        [HttpGet]
        public Customer ReadById(int Id)
        {
            return new Facade().GetCustomerRepository().ReadById(Id);
        }

        [HttpPost]
        public Customer AddCustomer(Customer customer)
        {
            return new Facade().GetCustomerRepository().Add(customer);
        }

        [HttpDelete]
        public void DeleteCustomer(Customer customer)
        {
            new Facade().GetCustomerRepository().Remove(customer);
        }

        [HttpPut]
        public Customer UpdateCustomer(int Id, Customer customer)
        {
            customer.Id = Id;
            return new Facade().GetCustomerRepository().Update(customer);
        }
    }
}
