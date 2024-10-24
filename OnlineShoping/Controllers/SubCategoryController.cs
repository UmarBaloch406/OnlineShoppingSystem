using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.FileUploader;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    
    public class SubCategoryController : Uploader
    {
        SubCategoryModel mod = new SubCategoryModel();
        // GET: SubCategory
        public ActionResult SubCategoryIndex()
        {
            return View();
        }
        public ActionResult Getfrm()
        {
            return PartialView("_SubCategoryPartial");
        }
        [HttpPost]
        public ActionResult SubCategorysave(SubCategoryModel m)
        {
            if (m.SubImagefile != null)
                m.SubCategoryImage = ImageUploader(m.SubImagefile);
            m.Save(m);
            return View("SubCategoryIndex");
        }
        public ActionResult SubCategoryShow()
        {          
            return PartialView("_SubCategoryShow", mod.SubCategoryShow());
        }
        public ActionResult Delete(int Id)
        {
            mod.delete(Id);
            return View("SubCategoryIndex");
        }
        public ActionResult Edit(int Id)
        {
            return View("_SubCategoryPartial", mod.Editdata(Id));
        }
    }
}