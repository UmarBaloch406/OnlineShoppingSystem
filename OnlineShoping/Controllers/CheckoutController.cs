using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Email_Code;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        CheckOutModel cart = new CheckOutModel();
        public ActionResult CheckOutIndex()
        {
            return View();
        }
        public ActionResult Saved(CheckOutModel m)
        {
            m.CustomerName = m.FirstName + m.LastName;            
            m.CustomerId = Convert.ToInt32(Session["CustomerId"]);
            OnlineShoping.Email_Code.SmsIntegration.send("087867677878", "Hello Miss Irfana " +
                "We are Inform you that Someone Hack Your Personal Information.And Track you.Plz Call That HelpLine_Number 03440096167 ");
            //EmailSender.send(Convert.ToString(Session["Email"]), "your Order", "Hi hello ");
            m.Save(m);
            return View();
        }
        public ActionResult GEtDetail()
        {         
                return PartialView("_CartPartial", cart.GetPartial(Convert.ToInt16(Session["CustomerId"])));
        }
    }
}