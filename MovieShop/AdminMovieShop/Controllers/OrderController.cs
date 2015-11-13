using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopGateway;

namespace AdminMovieShop.Controllers
{
    public class OrderController : Controller
    {
        Facade facade = new Facade();
        // GET: Order
        public ActionResult Index()
        {
            return View(facade.GetOrderGateway().ReadAll());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            facade.GetOrderGateway().Delete(facade.GetOrderGateway().ReadById(Id));
            return RedirectToAction("Index", "Order");
        }
    }
}

