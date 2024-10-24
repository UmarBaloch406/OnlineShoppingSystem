using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineShoping.DL;

namespace OnlineShoping.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public String CustomerFirstName { get; set; }
        public String CustomerLastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Contact { get; set; }
        public String Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public String Address { get; set; }
        public String zipCode { get; set; }
        public int Status { get; set; }
      
        public int Save(CustomerModel m)
        {
            SqlParameter[] prm = new SqlParameter[10];
            prm[0] = new SqlParameter("@Type",1);
            prm[1] = new SqlParameter("@CustomerFirstName", m.CustomerFirstName);
            prm[2] = new SqlParameter("@CustomerLastName", m.CustomerLastName);
            prm[3] = new SqlParameter("@Email", m.Email);
            prm[4] = new SqlParameter("@Password", m.Password);
            prm[5] = new SqlParameter("@Contact", m.Contact);
            prm[6] = new SqlParameter("@Image", m.Image);
            prm[7] = new SqlParameter("@Address", m.Address);
            prm[8] = new SqlParameter("@zipCode", m.zipCode);
            prm[9] = new SqlParameter("@Status", m.Status);
            return DLHelper.ExecuteQuerry("Sp_Tbl_Customer", prm);
        }
        public CustomerModel GetData(string Email,string Password)
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("@Type", 2);
            prm[1] = new SqlParameter("@Email", Email);
            prm[2] = new SqlParameter("@Password", Password);

            DataTable dt = DLHelper.getdata("Sp_Tbl_Customer", prm);

            if (dt.Rows.Count > 0)
            {

                CustomerModel m = new CustomerModel();
                m.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                m.CustomerFirstName = Convert.ToString(dt.Rows[0]["CustomerFirstName"]);
                m.CustomerLastName = Convert.ToString(dt.Rows[0]["CustomerLastName"]);
                m.Email = Convert.ToString(dt.Rows[0]["Email"]);
                m.Password = Convert.ToString(dt.Rows[0]["Password"]);
 
                return m;
            }
            return new CustomerModel();

        }
    }
}