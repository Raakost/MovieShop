using DomainModel;
using MovieShopGateway.Services.IGatewayService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopGateway.Services
{
    public class OrderGatewayService : IGatewayService<Order>
    {
        public Order Add(Order model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Order ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
