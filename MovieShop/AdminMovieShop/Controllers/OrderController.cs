using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesShopProxy;
using MoviesShopProxy.DomainModel;

namespace AdminMovieShop.Controllers
{
    public class OrderController : Controller
    {
        Facade facade = new Facade();
        // GET: Order
        public ActionResult Index()
        {
            return View(facade.GetOrderRepository().ReadAll());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            facade.GetOrderRepository().Remove(facade.GetOrderRepository().ReadById(Id));
            return RedirectToAction("Index", "Order");
        }
    }
}

