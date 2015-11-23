using DomainModel;
using MovieShopGateway;
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
            var customer = facade.GetCustomerGateway().ReadByEmail(Email);
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
            if (facade.GetCustomerGateway().ReadById(customer.Id) == null)
            {
                facade.GetCustomerGateway().Add(customer);
            }
            facade.GetOrderGateway().Add(new Order()
            {
                Customer = customer,
                Movies = ((List<Movie>)Session["Cart"]),
                Date = DateTime.Now
            });
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}