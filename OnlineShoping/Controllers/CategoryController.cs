using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.FileUploader;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    
    public class CategoryController : Uploader
    {
        CategoryModel mod = new CategoryModel();
        // GET: Category
        public ActionResult CategoryIndex()
        {
            
            return View(Session["image"]);
        }
        //CategoryModal
        public ActionResult GETFrm()
        {
            return PartialView("_CategoryPartial");
        }
        [HttpPost]
        public ActionResult Categorysave(CategoryModel m)
        {
            if (m.Imagefilee != null)
                m.Image = ImageUploader(m.Imagefilee);            
            m.Save(m);
            return View("CategoryIndex");
        }
        //ListShow
        public ActionResult CategoryShow()
        {

            return PartialView("_CategoryShow", mod.CategoryShow());
        }
        //Model for discription
        public ActionResult DiscriptionModal(int Id)
        {
            
            return PartialView("_DiscriptionModal", mod.dismodel(Id));
        }
        public ActionResult Delete(int Id)
        {
            mod.delete(Id);
            return View("CategoryIndex");
        }
        public ActionResult Edit(int Id)
        {
            return View("_CategoryPartial", mod.Editdata(Id));
        }
    }
}