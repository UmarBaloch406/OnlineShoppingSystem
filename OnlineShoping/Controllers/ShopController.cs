using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{   
    public class ShopController : Controller
    {

        AllModel modl = new AllModel();
        CategoryModel category = new CategoryModel();
        SubCategoryModel Subcategory = new SubCategoryModel();
        ProductModel product = new ProductModel();
        PriceModel price = new PriceModel();
        SizeModel Size = new SizeModel();

        // GET: Shop
        public ActionResult ShopIndex()
        {
            modl.Categorys = category.CategoryShow();
            modl.SubCategorys=Subcategory.SubCategoryShow();
            return View(modl);
        }
        public ActionResult ShopProductGet(int? Id, string Range)
        {
           
            int Minprice = Convert.ToInt32(Range.Split('-')[0].Replace('$', ' ').Trim());
            int Maxprice = Convert.ToInt32(Range.Split('-')[1].Replace('$', ' ').Trim());
            return PartialView("_ShopProduct",product.ProductShow(Id, Minprice, Maxprice));
        }
        public ActionResult ProductDetailIndex(int? Id)
        {
            modl.singleProduct = product.GetData(Id);
            modl.Products = product.ProductShow(Id);
            modl.Prices = price.PriceShowModel(Id);
            //modl.Sizes = Size.SizeShow();
            return View(modl);
        }
        public ActionResult Sizes()
        {
            var List = Size.SizeShow();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBySubCatId(int Id)
        {         
            return PartialView("_ReleatedProducts", product.ProductShow(Id));
        }

    }
}