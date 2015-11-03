using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieShopDAL.Repository
{
    public class OrderRepository
    {
        public List<Order> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Orders.Include(x => x.Customer).ToList();
            }
        }

        public void Add(Order order)
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
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
        }

        public Order ReadById(int Id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Orders.Where(order => order.Id == Id).FirstOrDefault();
            }
        }

        public void Remove(Order order)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderToDelete = ctx.Orders.Where(Order => Order.Id == order.Id).FirstOrDefault();
                ctx.Orders.Remove(orderToDelete);
                ctx.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderToUpdate = ctx.Orders.Where(Order => Order.Id == order.Id).FirstOrDefault();
                if (orderToUpdate != null)
                {
                    orderToUpdate.Movies = order.Movies; 
                    ctx.SaveChanges();
                }
            }
        }
    }
}
