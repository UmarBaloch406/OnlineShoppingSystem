using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSVersion2.Utils;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        OrderModel orderModel=new OrderModel();
        public ActionResult OrderIndex()
        {
            return View();
        }
        public ActionResult OrderGet()       
        {

          return PartialView("_OrderPartial", orderModel.GetOrder());
        }

        public ActionResult ChangeStatusMod(int Id , string CustomerName, string Email)
        {
            orderModel.OrderId= Id;
            orderModel.CustomerName = CustomerName;
            orderModel.CustomerEmail= Email;
            return PartialView("_ChangeStatus",orderModel);
        }
        
        public int statusUpdate(OrderModel m)
        {  
            if(m.status==0)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail",m.CustomerEmail, "Order Detail", " Your Order is Pending", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 1;
            }
            else if (m.status == 1)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail", m.CustomerEmail, "Order Detail", " Your Order is on Accept", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 2;
            }
            else if (m.status == 2)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail", m.CustomerEmail, "Order Detail", " Your Order is InProcess", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 3;
            }
            else if (m.status == 3)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail", m.CustomerEmail, "Order Detail", " Your Order is Shipped", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 4;
            }
            else if (m.status == 4)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail", m.CustomerEmail, "Order Detail", " Your Order is Received", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 5;
            }
            else if (m.status == 5)
            {
                orderModel.UpdateStatus(m);
                EmailTemplate.CommonTemplate("Order Detail", m.CustomerEmail, "Order Detail", " Your Order is Reject", "", "Visit our Website ", "Dear Customer " + m.CustomerName);

                return 6;
            }
            return 7;

        }
    }
}