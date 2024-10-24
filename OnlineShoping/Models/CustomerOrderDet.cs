using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class CustomerOrderDet
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public int zipCode { get; set; }
        public string Contact { get; set; }
       
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }

        public List<CustomerOrderDet> GetCusOrder(int CustomerId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@CustomerId", CustomerId);

            DataTable dt = DLHelper.getdata("sp_tbl_Ordered", prm);
            List<CustomerOrderDet> list = new List<CustomerOrderDet>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomerOrderDet m = new CustomerOrderDet();
                    m.OrderId = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                    m.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    m.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    m.Date = Convert.ToDateTime(dt.Rows[i]["Orderdate"]);
                    m.zipCode = Convert.ToInt32(dt.Rows[i]["zipCode"]);
                    m.Address = Convert.ToString(dt.Rows[i]["Address"]);

                    list.Add(m);
                }
            }
            return list;
        }
    }

}