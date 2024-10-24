using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class SizeModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int SizeStatus { get; set; }

        public int Save(SizeModel siz)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 1);
            prm[1] = new SqlParameter("@SizeName", siz.SizeName);
            prm[2] = new SqlParameter("@SizeStatus", siz.SizeStatus);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Size",prm);
        }
        public List<SizeModel> SizeShow()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);

            DataTable dt = DLHelper.getdata("Sp_Tbl_Size", prm);
            List<SizeModel> list = new List<SizeModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SizeModel m = new SizeModel();
                    m.SizeId = Convert.ToInt32(dt.Rows[i]["SizeId"]);
                    m.SizeName = Convert.ToString(dt.Rows[i]["SizeName"]);
                    m.SizeStatus = Convert.ToInt32(dt.Rows[i]["SizeStatus"]);
                    list.Add(m);
                }
            }
            return list;
        }

    }
    
}