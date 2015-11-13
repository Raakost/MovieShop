using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieShopDAL.Repository.iRepository;

namespace MovieShopDAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public IEnumerable<Order> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Orders.Include(x => x.Customer).ToList();
            }
        }

        public Order Add(Order order)
        {
            using (var ctx = new MovieShopContext())
            {
                List<Movie> movies = new List<Movie>();
                foreach (var movie in order.Movies)
                {
                    movies.Add(ctx.Movies.FirstOrDefault(movieToSearch => movieToSearch.Id == movie.Id));
                }
                order.Movies = movies;
                order.Customer = ctx.Customers.FirstOrDefault(cust => cust.Id == order.Customer.Id);
                var orderToReturn = ctx.Orders.Add(order);
                ctx.SaveChanges();
                return orderToReturn;
            }
        }

        public Order ReadById(int Id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Orders.FirstOrDefault(order => order.Id == Id);
            }
        }

        public void Remove(Order order)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderToDelete = ctx.Orders.FirstOrDefault(Order => Order.Id == order.Id);
                ctx.Orders.Remove(orderToDelete);
                ctx.SaveChanges();
            }
        }

        public Order Update(Order order)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderToUpdate = ctx.Orders.FirstOrDefault(Order => Order.Id == order.Id);
                if (orderToUpdate != null)
                {
                    orderToUpdate.Movies = order.Movies; 
                    ctx.SaveChanges();
                    return orderToUpdate;
                }
                return order;
            }
        }
    }
}
