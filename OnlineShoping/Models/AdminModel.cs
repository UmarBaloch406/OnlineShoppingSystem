using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class AdminModel
    {
        public int AdminId { get; set; }
        public int IsAdmin { get; set; }
        public int AdminStatus { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminContact { get; set; }
        public string AdminAddress { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string NewPassword { get; set; }
        public string conformPassword { get; set; }
        public string AdminImage { get; set; }
        public HttpPostedFileBase Imagefile { get; set; }


        public int TotalCategory { get; set; }
        public int ActiveCategory { get; set; }
        public int InActiveCategory { get; set; }
        public int TotalSubCategory { get; set; }
        public int ActiveSubCategory { get; set; }
        public int InActiveSubCategory { get; set; }
        public int TotalProduct { get; set; }
        public int ActiveProduct { get; set; }
        public int InActiveProduct { get; set; }

        public int Save(AdminModel m)
        {
            SqlParameter[] prm = new SqlParameter[9];
            prm[0] = new SqlParameter("@Type",m.AdminId==0?1:3);
            prm[1] = new SqlParameter("@AdminId", m.AdminId);
            prm[2] = new SqlParameter("@AdminEmail",m.AdminEmail);
            //prm[3] = new SqlParameter("@AdminPassword", m.AdminPassword);
            prm[3] = new SqlParameter("@AdminContact", m.AdminContact);
            prm[4] = new SqlParameter("@AdminAddress", m.AdminAddress);
            prm[5] = new SqlParameter("@AdminStatus", m.AdminStatus);
            prm[6] = new SqlParameter("@AdminFirstName", m.AdminFirstName);
            prm[7] = new SqlParameter("@AdminLastName", m.AdminLastName);
            prm[8] = new SqlParameter("@AdminImage", m.AdminImage);
            return DLHelper.ExecuteQuerry("sp_Tbl_Admin", prm);
        }

        public int PasswordSave(AdminModel m)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type",5);
            prm[1] = new SqlParameter("@AdminId", m.AdminId);
            prm[2] = new SqlParameter("@AdminPassword", m.NewPassword);
            return DLHelper.ExecuteQuerry("sp_Tbl_Admin", prm);
        }
        public int Imagesave(AdminModel m)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 6);
            prm[1] = new SqlParameter("@AdminId", m.AdminId);
            prm[2] = new SqlParameter("@AdminImage", m.AdminImage);
            return DLHelper.ExecuteQuerry("sp_Tbl_Admin", prm);
        }
        public AdminModel GetAdmin(string AdminEmail,string AdminPassword)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@AdminEmail", AdminEmail);
            prm[2] = new SqlParameter("@AdminPassword", AdminPassword);
            DataTable dt = DLHelper.getdata("sp_Tbl_Admin", prm);
            if (dt.Rows.Count > 0)
            {
                AdminModel m = new AdminModel();
                m.AdminId = Convert.ToInt32(dt.Rows[0]["AdminId"]);
                m.AdminFirstName = Convert.ToString(dt.Rows[0]["AdminFirstName"]);
                m.AdminLastName = Convert.ToString(dt.Rows[0]["AdminLastName"]);
                m.AdminImage = Convert.ToString(dt.Rows[0]["AdminImage"]);
                m.AdminEmail = Convert.ToString(dt.Rows[0]["AdminEmail"]);
                m.AdminPassword = Convert.ToString(dt.Rows[0]["AdminPassword"]);             
                m.AdminContact = Convert.ToString(dt.Rows[0]["AdminContact"]);             
                m.AdminAddress = Convert.ToString(dt.Rows[0]["AdminAddress"]);
                m.AdminStatus = Convert.ToInt32(dt.Rows[0]["AdminStatus"]);
                return m;
            }
            return new AdminModel();
        }
        public AdminModel select(int AdminId)
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("@Type", 4);
            prm[1] = new SqlParameter("@AdminId", AdminId);
            DataTable dt = DLHelper.getdata("sp_Tbl_Admin", prm);
            if (dt.Rows.Count > 0)
            {
                AdminModel m = new AdminModel();
                m.AdminId = Convert.ToInt32(dt.Rows[0]["AdminId"]);
                m.AdminFirstName = Convert.ToString(dt.Rows[0]["AdminFirstName"]);
                m.AdminLastName = Convert.ToString(dt.Rows[0]["AdminLastName"]);
                m.AdminImage = Convert.ToString(dt.Rows[0]["AdminImage"]);
                m.AdminEmail = Convert.ToString(dt.Rows[0]["AdminEmail"]);
                m.AdminPassword = Convert.ToString(dt.Rows[0]["AdminPassword"]);
                m.AdminContact = Convert.ToString(dt.Rows[0]["AdminContact"]);
                m.AdminAddress = Convert.ToString(dt.Rows[0]["AdminAddress"]);
                return m;
            }
            return new AdminModel();
        }
        public AdminModel AdminDeshboard()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Type", 7);
  
            DataTable dt = DLHelper.getdata("sp_Tbl_Admin", prm);
            if (dt.Rows.Count > 0)
            {
                AdminModel m = new AdminModel();
                m.TotalCategory = Convert.ToInt32(dt.Rows[0]["TotalCategory"]);
                m.ActiveCategory = Convert.ToInt32(dt.Rows[0]["ActiveCategory"]);
                m.InActiveCategory = Convert.ToInt32(dt.Rows[0]["InActiveCategory"]);
                m.TotalSubCategory = Convert.ToInt32(dt.Rows[0]["TotalSubCategory"]);
                m.ActiveSubCategory = Convert.ToInt32(dt.Rows[0]["ActiveSubCategory"]);
                m.InActiveSubCategory = Convert.ToInt32(dt.Rows[0]["InActiveSubCategory"]);
                m.TotalProduct = Convert.ToInt32(dt.Rows[0]["TotalProduct"]);
                m.ActiveProduct = Convert.ToInt32(dt.Rows[0]["ActiveProduct"]);
                m.InActiveProduct = Convert.ToInt32(dt.Rows[0]["InActiveProduct"]);
                return m;
            }
            return new AdminModel();
        }
    }
    }

