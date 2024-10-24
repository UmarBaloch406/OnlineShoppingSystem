using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class CategoryModel
    {
        public int CatogaryId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }     
        public HttpPostedFileBase Imagefilee { get; set; }




        public int Save(CategoryModel m)
        {
            SqlParameter[] prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@Type", m.CatogaryId==0?1:6);
            prm[1] = new SqlParameter("@CatogaryId", m.CatogaryId);
            prm[2] = new SqlParameter("@Name",m.Name);
            prm[3] = new SqlParameter("@Discription", m.Discription);
            prm[4] = new SqlParameter("@Status",m.Status);
            prm[5] = new SqlParameter("@Image",m.Image);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Catogary", prm);
        }
        public List<CategoryModel> CategoryShow()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 2);
            
            DataTable dt = DLHelper.getdata("Sp_Tbl_Catogary", prm);
            List<CategoryModel> list = new List<CategoryModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoryModel m = new CategoryModel();
                    m.CatogaryId = Convert.ToInt32(dt.Rows[i]["CatogaryId"]);
                    m.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    m.Discription = Convert.ToString(dt.Rows[i]["Discription"]);
                    m.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    m.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    m.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    list.Add(m);
                }
            }
            return list;
        }
        public CategoryModel dismodel(int Id)
            {
                SqlParameter[] prm = new SqlParameter[2];
                prm[0] = new SqlParameter("@Type", 3);
                prm[1] = new SqlParameter("@CatogaryId", Id);           
                DataTable dt = DLHelper.getdata("Sp_Tbl_Catogary", prm);
                if (dt.Rows.Count > 0)
                {
                        CategoryModel m = new CategoryModel();                        
                        m.Discription = Convert.ToString(dt.Rows[0]["Discription"]);                       
                        return m;                 
                }
                return new CategoryModel();
            }




        public CategoryModel Editdata(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 5);
            prm[1] = new SqlParameter("@CatogaryId", Id);
            DataTable dt = DLHelper.getdata("Sp_Tbl_Catogary", prm);
            if (dt.Rows.Count > 0)
            {
                CategoryModel m = new CategoryModel();
                m.CatogaryId = Convert.ToInt32(dt.Rows[0]["CatogaryId"]);
                m.Name = Convert.ToString(dt.Rows[0]["Name"]);
                m.Discription = Convert.ToString(dt.Rows[0]["Discription"]);
                m.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                m.Image = Convert.ToString(dt.Rows[0]["Image"]);
                return m;
            }
            return new CategoryModel();
        }
        public int delete(int Id)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@CatogaryId", Id);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Catogary", prm);
          }
        }
}