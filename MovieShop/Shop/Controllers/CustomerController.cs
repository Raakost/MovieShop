using MoviesShopProxy;
using MoviesShopProxy.DomainModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CustomerController : Controller
    {
        Facade facade = new Facade();

        // GET: Customer
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CustomerConfirmation(string Email)
        {
            var customer = facade.GetCustomerRepository().ReadByEmail(Email);
            if (customer == null)
            {
                customer = new Customer()
                {
                    Email = Email
                };
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult CustomerPlaceOrder(Customer customer)
        {
            if (facade.GetCustomerRepository().ReadById(customer.Id) == null)
            {
                facade.GetCustomerRepository().Add(customer);
            }
            facade.GetOrderRepository().Add(new Order()
            {
                Customer = customer,
                Movies = ((List<Movie>)Session["Cart"]),
                Date = DateTime.Now
            });
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}