using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class CheckOutModel
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public int zipCode { get; set; }
        public string Contact { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Cnic { get; set; }
        public string Image { get; set; }



        public int Save(CheckOutModel m)
        {
        SqlParameter[] prm = new SqlParameter[6];
        prm[0] = new SqlParameter("@Type", 1);
        prm[1] = new SqlParameter("@Contact", m.Contact);
        prm[2] = new SqlParameter("@CustomerName", m.CustomerName);
        prm[3] = new SqlParameter("@Address", m.Address);
        prm[4] = new SqlParameter("@zipCode", m.zipCode);
        prm[5] = new SqlParameter("@CustomerId", m.CustomerId);

            return DLHelper.ExecuteQuerry("sp_tbl_Ordered", prm);
        }
        public List<CheckOutModel> GetPartial(int? CustomerId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@CustomerId", CustomerId);

            DataTable dt = DLHelper.getdata("sp_tbl_Ordered", prm);
            List<CheckOutModel> list = new List<CheckOutModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckOutModel m = new CheckOutModel();
                    
                    m.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    m.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                    m.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    m.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    m.ProductName=Convert.ToString(dt.Rows[i]["ProductName"]);
                    list.Add(m);
                }
            }
            return list;
        }

        public List<CheckOutModel> billShow(int? OrderId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@OrderId", OrderId);


            DataTable dt = DLHelper.getdata("sp_tbl_Ordered", prm);
            List<CheckOutModel> list = new List<CheckOutModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckOutModel m = new CheckOutModel();
                    m.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    m.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    m.zipCode = Convert.ToInt32(dt.Rows[i]["zipCode"]);
                    m.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    m.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    m.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    m.OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                    m.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    m.Contact = Convert.ToString(dt.Rows[i]["Contact"]);
                    m.CreatedDate= Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    m.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    list.Add(m);
                }
            }
            return list;
        }
    }
}