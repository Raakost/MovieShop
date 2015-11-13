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
    public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Order> ReadAll()
        {
            return new Facade().GetOrderRepository().ReadAll();
        }

        [HttpGet]
        public Order ReadById(int Id)
        {
            return new Facade().GetOrderRepository().ReadById(Id);
        }

        [HttpPost]
        public Order AddOrder(Order order)
        {
            return new Facade().GetOrderRepository().Add(order);
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var order = new Order() {Id = id};
            new Facade().GetOrderRepository().Remove(order);
        }

        [HttpPut]
        public Order UpdateOrder(Order order, int Id)
        {
            order.Id = Id;
            return new Facade().GetOrderRepository().Update(order);
        }

    }
}
