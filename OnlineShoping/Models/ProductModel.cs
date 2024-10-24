using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
        public int CatogaryId { get; set; }
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }
        public List<HttpPostedFileBase> Imagefilee { get; set; }
        public string Discription { get; set; }
        public bool IsNewArrival { get; set; }
        public bool HotDeal { get; set; }
        public decimal price { get; set; }

        public int Save(ProductModel m)
        {
            SqlParameter[] prm = new SqlParameter[13];
            prm[0] = new SqlParameter("@Type", 1);
            prm[1] = new SqlParameter("@ProductName", m.ProductName);
            prm[2] = new SqlParameter("@UnitId", m.UnitId);
            prm[3] = new SqlParameter("@ColorId", m.ColorId);
            prm[4] = new SqlParameter("@BrandId", m.BrandId);
            prm[5] = new SqlParameter("@CatogaryId", m.CatogaryId);
            prm[6] = new SqlParameter("@SubCategoryId", m.SubCategoryId);
            prm[7] = new SqlParameter("@Discount", m.Discount);
            prm[8] = new SqlParameter("@Status", m.Status);
            prm[9] = new SqlParameter("@Image", m.Image);
            prm[10] = new SqlParameter("@Discription", m.Discription);
            prm[11] = new SqlParameter("@IsNewArrival", m.IsNewArrival);
            prm[12] = new SqlParameter("@HotDeal", m.HotDeal);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Productt", prm);
        }
        public List<ProductModel> ProductShow(int? Id = null,int? Minprice =null, int? Maxprice=null)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@SubCategoryId", Id);
            prm[2] = new SqlParameter("@Minprice", Minprice);
            prm[3] = new SqlParameter("@Maxprice", Maxprice);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Productt", prm);
            List<ProductModel> list = new List<ProductModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductModel m = new ProductModel();
                    m.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    m.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    m.UnitId = Convert.ToInt32(dt.Rows[i]["UnitId"]);
                    m.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                    m.ColorId = Convert.ToInt32(dt.Rows[i]["ColorId"]);
                    m.ColorName = Convert.ToString(dt.Rows[i]["ColorName"]);
                    m.BrandId = Convert.ToInt32(dt.Rows[i]["BrandId"]);
                    m.CatogaryId = Convert.ToInt32(dt.Rows[i]["CatogaryId"]);
                    m.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    m.SubCategoryName = Convert.ToString(dt.Rows[i]["SubCategoryName"]);
                    m.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                    m.Discount = Convert.ToInt32(dt.Rows[i]["Discount"]);
                    m.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    m.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    m.Discription = Convert.ToString(dt.Rows[i]["Discription"]);
                    m.IsNewArrival = Convert.ToBoolean(dt.Rows[i]["IsNewArrival"]);
                    m.HotDeal = Convert.ToBoolean(dt.Rows[i]["HotDeal"]);
                    //m.price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public ProductModel GetData(int? Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ProductId", Id);
           
            DataTable dt = DLHelper.getdata("Sp_Tbl_Productt", prm);

            if (dt.Rows.Count > 0)
            {
                
                    ProductModel m = new ProductModel();
                    m.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"]);
                    m.ProductName = Convert.ToString(dt.Rows[0]["ProductName"]);
                    m.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                    m.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);
                    m.ColorId = Convert.ToInt32(dt.Rows[0]["ColorId"]);
                    m.ColorName = Convert.ToString(dt.Rows[0]["ColorName"]);
                    m.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"]);
                    m.CatogaryId = Convert.ToInt32(dt.Rows[0]["CatogaryId"]);
                    m.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    m.SubCategoryName = Convert.ToString(dt.Rows[0]["SubCategoryName"]);
                    m.SubCategoryId = Convert.ToInt32(dt.Rows[0]["SubCategoryId"]);
                    m.Discount = Convert.ToInt32(dt.Rows[0]["Discount"]);
                    m.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                    m.Image = Convert.ToString(dt.Rows[0]["Image"]);
                    m.Discription = Convert.ToString(dt.Rows[0]["Discription"]);
                return m;
                }
            return new ProductModel();
            
        }
    }
}
