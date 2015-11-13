using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Movie>();
            }
            return PartialView(((List<Movie>)Session["Cart"]));
        }
    }
}