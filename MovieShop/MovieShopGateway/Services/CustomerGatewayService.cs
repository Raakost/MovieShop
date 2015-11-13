using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using MovieShopGateway.Services.IGatewayService;

namespace MovieShopGateway.Services
{
    public class CustomerGatewayService : IGatewayService<Customer>
    {
        public Customer Add(Customer model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Customer ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer model)
        {
            throw new NotImplementedException();
        }

        public Customer ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
