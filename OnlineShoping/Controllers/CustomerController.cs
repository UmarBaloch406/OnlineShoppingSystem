using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSVersion2.Utils;
using OnlineShoping.FileUploader;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class CustomerController : Uploader
    {
        // GET: Customer
        CustomerModel modl = new CustomerModel();

       

        public ActionResult CustomarIndex()
        {
            return View();
        }
        public int Save(CustomerModel m)
        {
            if (m.ImageFile != null) 
            {
                m.Image = ImageUploader(m.ImageFile);
                m.Save(m);
                EmailTemplate.CommonTemplate("Your Registration is Successfully Completed", m.Email, "Registration Page", " You have Sucessfuly Complete your Registration.Thanks For Visiting Me.", "", "Visit our Website ", "Dear Customer " + m.CustomerFirstName + m.CustomerLastName);

                return 1;
            }
            else
            {
                return 0;
            }
        }
        public ActionResult LoginIndex()
        {
            return View();
        }
        public ActionResult LoginFormGet()
        {
            return PartialView("_LoginFormGet");
        }
        public int LoginSave(CustomerModel m)
        {
            var data = modl.GetData(m.Email, m.Password);
            
            if(data.CustomerId>0)
            {
                Session["CustomerId"] = data.CustomerId;
                Session["Email"] = data.Email;
                
                return 1;
            }
           else
            return 2;
        }
    }
}