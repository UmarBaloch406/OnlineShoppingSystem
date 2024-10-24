using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public int zipCode { get; set; }
        public String Contact { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int status { get; set; }

        public int UpdateStatus(OrderModel m)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 6);
            prm[1] = new SqlParameter("@Status", m.status);
            prm[2] = new SqlParameter("@OrderId", m.OrderId);
            return DLHelper.ExecuteQuerry("sp_tbl_Ordered", prm);
        }

        public List<OrderModel> GetOrder()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 5);
       
            DataTable dt = DLHelper.getdata("sp_tbl_Ordered", prm);
            List<OrderModel> list = new List<OrderModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OrderModel m = new OrderModel();
                    m.OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                    m.status = Convert.ToInt32(dt.Rows[i]["status"]);
                    m.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    m.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    m.Date = Convert.ToDateTime(dt.Rows[i]["Orderdate"]);
                    m.zipCode = Convert.ToInt32(dt.Rows[i]["zipCode"]);
                    m.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    m.CustomerEmail = Convert.ToString(dt.Rows[i]["Email"]);
                    

                    list.Add(m);
                }
            }
            return list;
        }
    }

}