using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class ColorModel
    { 
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public bool IsDeleted { get; set; }
        public int ColorStatus { get; set; }

        public int Save(ColorModel m)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type",m.ColorId==0?1:5);
            prm[1] = new SqlParameter("@ColorId", m.ColorId);
            prm[2] = new SqlParameter("@ColorName", m.ColorName);
            prm[3] = new SqlParameter("@ColorStatus", m.ColorStatus);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Color", prm);
        }
        public List<ColorModel> ColorShow()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Color", prm);
            List<ColorModel> list = new List<ColorModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ColorModel m = new ColorModel();
                    m.ColorId = Convert.ToInt32(dt.Rows[i]["ColorId"]);
                    m.ColorName = Convert.ToString(dt.Rows[i]["ColorName"]);
                    m.ColorStatus = Convert.ToInt32(dt.Rows[i]["ColorStatus"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public ColorModel Edit(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@ColorId", Id);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Color", prm);
            if (dt.Rows.Count > 0)
            {
                ColorModel m = new ColorModel();
                m.ColorId = Convert.ToInt32(dt.Rows[0]["ColorId"]);
                m.ColorName = Convert.ToString(dt.Rows[0]["ColorName"]);
                m.ColorStatus = Convert.ToInt32(dt.Rows[0]["ColorStatus"]);
                return m;
            }
            return new ColorModel();
        }

        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@ColorId", Id);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Color", prm);
        }
    }
}