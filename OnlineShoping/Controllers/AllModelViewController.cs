using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class AllModelViewController : Controller
    {
        // GET: AllModelView
        AllModel AllMod=new AllModel();
        ProductModel product=new ProductModel();
        CategoryModel category=new CategoryModel();
        SubCategoryModel SubCategory=new SubCategoryModel();
        ColorModel color=new ColorModel();
        UnitModel unit=new UnitModel();
        PriceModel price=new PriceModel();
     
        public ActionResult AllModelIndex()
        {
            AllMod.Products = product.ProductShow();
            AllMod.Categorys=category.CategoryShow();
            AllMod.SubCategorys=SubCategory.SubCategoryShow();
            AllMod.Colors=color.ColorShow();
            AllMod.Units=unit.UNITShow();
            AllMod.Prices=price.PriceShow();
         return View(AllMod);
        }
        public ActionResult SubCatformGet(int Id)
        {

            return PartialView("_SubCatFormGet",SubCategory.SubCategoryShow(Id));
        }

        public ActionResult categoryShowinline()
        {
            AllMod.Categorys = category.CategoryShow();
            AllMod.SubCategorys = SubCategory.SubCategoryShow();
            return PartialView("_CategoryShowinline", AllMod);
        }


    }
}