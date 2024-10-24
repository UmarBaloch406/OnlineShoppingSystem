using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        CartModel cart = new CartModel();
       
        public ActionResult CartIndex()
        {
            return View();
        }
        public ActionResult CartPartial()
        {
            return PartialView("_CartPartial", cart.GetCarts(Convert.ToInt32(Session["CustomerId"])));
        }
        public int Save(int productid, int sizeid,int Quantity)
        {
            if(Session["CustomerId"]!=null)
            {
                cart.ProductId = productid;
                cart.SizeId = sizeid;
                cart.Quantity = Quantity;
                cart.CustomerId = Convert.ToInt32(Session["CustomerId"]);
                cart.Save(cart);
                return 1;
            }
            else
            {
                return 2;
            }
           
        }
        public int updateQuantity(int cartid, int Quantity)
        {
            CartModel m = new CartModel();
            m.CartId = cartid;
            m.Quantity = Quantity;
            cart.CartUpdate(m);
            return 1;
        }
    }
}