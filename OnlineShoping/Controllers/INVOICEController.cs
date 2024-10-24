using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class INVOICEController : Controller
    {
        CheckOutModel model = new CheckOutModel();
        // GET: INVOICE

        public ActionResult InVoiceIndex(int? OrderId)
        {
            if (OrderId != null)
            {
                var m = model.billShow(OrderId);
                return View(m);
            }
            else
                return RedirectToAction("OrderIndex", "Order");
            
        }
     
    }
}