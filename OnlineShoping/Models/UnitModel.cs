using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class UnitModel
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int Status { get; set; }

        public int Save(UnitModel m)
        {
            SqlParameter[] prm = new SqlParameter[4];
            prm[0] = new SqlParameter("@Type",m.UnitId==0?1:5);
            prm[1] = new SqlParameter("@UnitId", m.UnitId);
            prm[2] = new SqlParameter("@UnitName", m.UnitName);
            prm[3] = new SqlParameter("@Status", m.Status);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Unit", prm);
        }
        public List<UnitModel> UNITShow()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Unit", prm);
            List<UnitModel> list = new List<UnitModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UnitModel m = new UnitModel();
                    m.UnitId = Convert.ToInt32(dt.Rows[i]["UnitId"]);
                    m.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                    m.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public UnitModel Edit(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@UnitId", Id);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Unit", prm);
            if (dt.Rows.Count > 0)
            {
                    UnitModel m = new UnitModel();
                    m.UnitId = Convert.ToInt32(dt.Rows[0]["UnitId"]);
                    m.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);
                    m.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                    return m;              
            }
            return new UnitModel();
        }

        public int Delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@UnitId", Id);          
            return DLHelper.ExecuteQuerry("Sp_Tbl_Unit", prm);
        }
    }
}
