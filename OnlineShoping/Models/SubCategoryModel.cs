using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class SubCategoryModel
    {
        public int SubCategoryId { get; set; }
        public int CatogaryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string SubCategoryImage { get; set; }
        public HttpPostedFileBase SubImagefile { get; set; }

        public int Save(SubCategoryModel m)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", SubCategoryId==0?1:5);
            prm[1] = new SqlParameter("@SubCategoryId", SubCategoryId);
            prm[2] = new SqlParameter("@CatogaryId", CatogaryId);
            prm[3] = new SqlParameter("@SubCategoryName", SubCategoryName);
            prm[4] = new SqlParameter("@Status", Status);
            prm[5] = new SqlParameter("@SubCategoryImage", SubCategoryImage);
            return DLHelper.ExecuteQuerry("Sp_Tbl_SubCategory", prm);
        }

        public List<SubCategoryModel> SubCategoryShow(int? CatogaryId= null)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@CatogaryId", CatogaryId);
            DataTable dt = DLHelper.getdata("Sp_Tbl_SubCategory", prm);
            List<SubCategoryModel> list = new List<SubCategoryModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SubCategoryModel m = new SubCategoryModel();
                    m.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                    m.CatogaryId = Convert.ToInt32(dt.Rows[i]["CatogaryId"]);
                    m.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    m.SubCategoryName = Convert.ToString(dt.Rows[i]["SubCategoryName"]);
                    m.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    m.SubCategoryImage = Convert.ToString(dt.Rows[i]["SubCategoryImage"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public SubCategoryModel Editdata(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@SubCategoryId", Id);
            DataTable dt = DLHelper.getdata("Sp_Tbl_SubCategory", prm);
            if (dt.Rows.Count > 0)
            {
                SubCategoryModel m = new SubCategoryModel();
                m.SubCategoryId= Convert.ToInt32(dt.Rows[0]["SubCategoryId"]);
                m.CatogaryId = Convert.ToInt32(dt.Rows[0]["CatogaryId"]);
                m.SubCategoryName = Convert.ToString(dt.Rows[0]["SubCategoryName"]);
                m.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                m.SubCategoryImage = Convert.ToString(dt.Rows[0]["SubCategoryImage"]);
                return m;
            }
            return new SubCategoryModel();
        }
        public int delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 3);
            prm[1] = new SqlParameter("@SubCategoryId", Id);
            return DLHelper.ExecuteQuerry("Sp_Tbl_SubCategory", prm);
        }


    }
}