using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class PriceModel
    {
        public int PriceId { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Save(PriceModel m)
        {
            SqlParameter[] prm = new SqlParameter[5];
            prm[0] = new SqlParameter("@Type",1);
            prm[1] = new SqlParameter("@PriceId", m.PriceId);
            prm[2] = new SqlParameter("@SizeId", m.SizeId);
            prm[3] = new SqlParameter("@Price", m.Price);
            prm[4] = new SqlParameter("@ProductId", m.ProductId);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Price", prm);
        }
        public List<PriceModel> PriceShow()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Price", prm);
            List<PriceModel> list = new List<PriceModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriceModel m = new PriceModel();
                    m.PriceId = Convert.ToInt32(dt.Rows[i]["PriceId"]);
                    m.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    m.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    m.SizeId = Convert.ToInt32(dt.Rows[i]["SizeId"]);
                    m.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    m.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public List<PriceModel> PriceShowModel(int? Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ProductId", Id);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Price", prm);
            List<PriceModel> list = new List<PriceModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PriceModel m = new PriceModel();
                    m.PriceId = Convert.ToInt32(dt.Rows[i]["PriceId"]);
                    m.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    m.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                    m.SizeId = Convert.ToInt32(dt.Rows[i]["SizeId"]);
                    m.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    m.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                    list.Add(m);
                }
            }
            return list;
        }
    }
}