using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class CustomerOrderDetailController : Controller
    {
        // GET: CustomerOrderDetail
        CustomerOrderDet mod = new CustomerOrderDet();
        public ActionResult CustomerOrder()
        {
            return View();
        }
        public ActionResult CustomerorderShow()
        {
            var data = mod.GetCusOrder(Convert.ToInt32(Session["CustomerId"]));

            return View("_CustomerorderShow",data );
        }
    }
}