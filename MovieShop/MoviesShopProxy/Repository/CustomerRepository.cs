using MoviesShopProxy.Context;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesShopProxy.Repository
{
    public class CustomerRepository
    {
        public List<Customer> ReadAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.ToList();
            }
        }

        public void Add(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
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
                    var customerToDelete = ctx.Customers.Where(cust => cust.Id == customer.Id).FirstOrDefault();
                    ctx.Customers.Remove(customerToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Customer cannot be deleted");
            }
        }

        public void Update(Customer customer)
        {
            using (var ctx = new MovieShopContext())
            {
                var customerToUpdate = ctx.Customers.Where(cust => cust.Id == customer.Id).FirstOrDefault();
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
                }
            }
        }
    }
}
