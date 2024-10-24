using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }

        public int Save(CartModel m)
        {
            SqlParameter[] prm = new SqlParameter[7];
            prm[0] = new SqlParameter("@Type", 1);
            prm[1] = new SqlParameter("@ProductId", m.ProductId);
            prm[2] = new SqlParameter("@SizeId", m.SizeId);
            prm[3] = new SqlParameter("@Price", m.Price);
            prm[4] = new SqlParameter("@TotalPrice", m.TotalPrice);
            prm[5] = new SqlParameter("@Quantity", m.Quantity);
            prm[6] = new SqlParameter("@CustomerId", m.CustomerId);
        
            return DLHelper.ExecuteQuerry("sp_Tbl_Cart", prm);
        }
        public int CartUpdate(CartModel m)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@CartId", m.CartId);
            prm[2] = new SqlParameter("@Quantity", m.Quantity);
            return DLHelper.ExecuteQuerry("sp_Tbl_Cart", prm);
        }
        public List<CartModel> GetCarts(int CustomerId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@CustomerId", CustomerId);

            DataTable dt = DLHelper.getdata("sp_Tbl_Cart", prm);
            List<CartModel> list = new List<CartModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CartModel m = new CartModel();
                    m.CartId = Convert.ToInt32(dt.Rows[i]["CartId"]);
                    m.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    m.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    m.SizeId = Convert.ToInt32(dt.Rows[i]["SizeId"]);
                    m.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    m.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    m.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    m.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    m.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                 
                    list.Add(m);
                }
            }
            return list;
        }
    }
}