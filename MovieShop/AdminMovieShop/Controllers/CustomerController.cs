using MoviesShopProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(facade.GetCustomerRepository().ReadAll());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try {
                facade.GetCustomerRepository().Remove(facade.GetCustomerRepository().ReadById(Id));
            } catch (Exception ex) { return RedirectToAction("Index", "Customer", new {error = ex.Message}); }
            return RedirectToAction("Index", "Customer");
        }


    }
}