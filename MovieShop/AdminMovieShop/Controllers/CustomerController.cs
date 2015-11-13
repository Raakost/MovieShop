using MovieShopGateway;
using DomainModel;
using System;
using System.Web.Mvc;

namespace AdminMovieShop.Controllers
{
    public class CustomerController : Controller
    {
        Facade facade = new Facade();
        // GET: Customer
        public ActionResult Index(string error)
        {
            ViewBag.CustomerError = error;
            return View(facade.GetCustomerGateway().ReadAll());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try {
                facade.GetCustomerGateway().Remove(facade.GetCustomerGateway().ReadById(Id));
            } catch (Exception ex) { return RedirectToAction("Index", "Customer", new {error = ex.Message}); }
            return RedirectToAction("Index", "Customer");
        }


    }
}