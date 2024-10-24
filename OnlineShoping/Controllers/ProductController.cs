using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.FileUploader;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
      public class ProductController : Uploader
    {
        SubCategoryModel modl=new SubCategoryModel();
        ProductModel prod = new ProductModel();
        // GET: Product
        public ActionResult ProductIndex()
        {
            return View();
        }

        public ActionResult ProductformGet(int? Id)
        {
            return PartialView("_ProductForm", prod.GetData(Id));
        }
        public ActionResult productDis(int? Id)
        {
            return PartialView("_productdis", prod.GetData(Id));
        }
        public int Save(ProductModel prod)
        {
           if(prod.Imagefilee.Count==4)
            {
                if (prod.Imagefilee != null)
                {
                    foreach (var img in prod.Imagefilee)
                    {
                        prod.Image += ImageUploader(img) + ",";
                    }
                    prod.Image = prod.Image.Remove(prod.Image.Length - 1);
                    prod.Save(prod);

                }
                return 1;
            }
            return 0;
        }
        public ActionResult getSubCategory(int CatogaryId)
        {
            var list = modl.SubCategoryShow(CatogaryId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductDataShow()
        {          
            return View();
        }
        public ActionResult ProductList()
        {
            var data = prod.ProductShow();           
            return PartialView("_ProductList", data);
        }
    }
}