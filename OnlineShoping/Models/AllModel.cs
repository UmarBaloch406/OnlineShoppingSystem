using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class AllModel
    {
        public AdminModel Admin { get; set; }
        public List<CategoryModel> Categorys { get; set; }
        public List<SubCategoryModel> SubCategorys { get; set; }
        public List<ProductModel> Products { get; set; }
        public ProductModel singleProduct { get; set; }
        public List<ColorModel> Colors { get; set; }
        public List<UnitModel> Units { get; set; }
        public List<PriceModel> Prices { get; set; }

        public List<SizeModel> Sizes { get; set; }
        public List<CartModel> Carts { get; set; }


    }
}