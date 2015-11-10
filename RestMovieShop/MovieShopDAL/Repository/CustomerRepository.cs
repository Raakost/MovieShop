using MovieShopDAL.Context;
using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.Repository.iRepository;

namespace MovieShopDAL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> IRepository<Customer>.ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.ToList();
            }
        }

        public Customer Add(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                var customerToReturn = ctx.Customers.Add(customer);
                ctx.SaveChanges();
                return customerToReturn;
            }
        }

        public Customer ReadById(int Id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.FirstOrDefault(cust => cust.Id == Id);
            }
        }

        public Customer ReadByEmail(string Email)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.FirstOrDefault(cust => cust.Email.Equals(Email));
            }
        }

        public void Remove(Customer customer)
        {
            try
            {
                using (var ctx = new MovieShopContext())
                {
                    var customerToDelete = ctx.Customers.FirstOrDefault(cust => cust.Id == customer.Id);
                    ctx.Customers.Remove(customerToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Customer cannot be deleted");
            }
        }

        public Customer Update(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                var customerToUpdate = ctx.Customers.FirstOrDefault(cust => cust.Id == customer.Id);
                if (customerToUpdate != null)
                {
                    customerToUpdate.Country = customer.Country;
                    customerToUpdate.Email = customer.Email;
                    customerToUpdate.Firstname = customer.Firstname;
                    customerToUpdate.Lastname = customer.Lastname;
                    customerToUpdate.StreetName = customer.StreetName;
                    customerToUpdate.StreetNumber = customer.StreetNumber;
                    customerToUpdate.Zipcode = customer.Zipcode;
                    ctx.SaveChanges();
                    return customerToUpdate;
                }
                return customer;
            }
        }
    }
}
