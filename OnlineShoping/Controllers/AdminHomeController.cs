using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineShoping.FileUploader;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    
    public class AdminHomeController : Uploader
    {
        AdminModel mod = new AdminModel();
        
        // GET: AdminHome
        public ActionResult AdminIndex()
        {         
            return View();
        }
        public ActionResult AdminFormget()
        {
            return View("_AdminFormShow");
        }
        public int Save(AdminModel m)
        {
            AdminModel data = m.GetAdmin(m.AdminEmail, m.AdminPassword);

            if (data.AdminId > 0)
            {
                Session["AdminId"] = data.AdminId;
                Session["image"] = data.AdminImage;
                Session["name"] = data.AdminFirstName + data.AdminLastName;
                Session["email"] = data.AdminEmail;
                Session["Password"] = data.AdminPassword;
                FormsAuthentication.SetAuthCookie(data.AdminEmail, false);
                return 1;
            }
            else
                return 2;
        }
        public ActionResult AdminIndexUpdate()
        {
            return View(Session["image"]);
        }
        public ActionResult FormUpdate()
        {
            var data = mod.select(Convert.ToInt32(Session["AdminId"]));
           
            return PartialView("_FormUpdate",data);
        }

        public ActionResult FormUpdateGet()
         {
            return PartialView("_AdminIndexUpdate");
        }


     
        public int UpdateSave(AdminModel admin)
        {
            Session["name"] = admin.AdminFirstName + admin.AdminLastName;
            admin.Save(admin);                  
            return 1;
        }
        public ActionResult FormImage()
        {
            var data = mod.select(Convert.ToInt32(Session["AdminId"]));
            return PartialView("_ImageForm",data);
        }
        public int ImageSave(AdminModel m)
        {
            if (m.Imagefile != null)
               m.AdminImage = ImageUploader(m.Imagefile);
            Session["image"] = m.AdminImage;
            m.Imagesave(m);
               return 1;
        }

        public ActionResult FormPassword()
        {
            return PartialView("_FormPassword");
        }
        public int PasswordSave(AdminModel m)
        {

               m.AdminId=Convert.ToInt32(Session["AdminId"]);
                m.PasswordSave(m);
  
            return 1;
        }
        public ActionResult AdminDeshboard()
        {
            var data=mod.AdminDeshboard();
            return View(data);
        }
    }
}