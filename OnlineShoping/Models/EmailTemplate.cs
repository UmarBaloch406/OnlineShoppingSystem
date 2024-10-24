using OnlineShoping.Email_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LMSVersion2.Utils
{
    public class EmailTemplate
    {
        public static bool CommonTemplate(string subject, string ToEmail, string PageHeader,
            string PageBody, string ClickHereUrl, string ClickHereLinkText, string SubTitle = "", string PageFooter = "Thanks",string AdminGmail="Mumar30406@gmail.Com")
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/CommonTemplate.html"));
            body = reader.ReadToEnd();
            body = body.Replace("@PageHeader", PageHeader);
            body = body.Replace("@PageBody", PageBody);
            body = body.Replace("@SubTitle", SubTitle);
            body = body.Replace("@LogoUrl", "https://eticmain.azurewebsites.net/assets/images/whiteLogo.png");
            body = body.Replace("@ProjectUrl", "https://eticmain.azurewebsites.net/");
            body = body.Replace("@ClickHereUrl", ClickHereUrl);
            body = body.Replace("@PageFooter", PageFooter);
            body = body.Replace("@ClickHereLinkText", ClickHereLinkText);
            body = body.Replace("@AdminGmail", AdminGmail);

            
            body = body.Replace("@Date", Convert.ToString(DateTime.Now));
            return EmailSender.send(ToEmail, subject, body);

        }

        //public static bool ForgotPassword(string EmailTitle, string email, string PageHeader,
        //  string PageBody, string LogoUrl = "https://hia.om/Logo/hiaWhiteLogo.png", string ProjectUrl = null)
        //{
        //    string body = string.Empty;
        //    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/ForgotPasswordEmailTemplate.html"));
        //    body = reader.ReadToEnd();
        //    body = body.Replace("@PageHeader", PageHeader);
        //    body = body.Replace("@PageBody", PageBody);
        //    body = body.Replace("@Logo", LogoUrl);
        //    body = body.Replace("@ProjectUrl", ProjectUrl);
        //    body = body.Replace("@Date", Convert.ToString(LocalDateTime.Now));
        //    return SendEmail.SendMail(email, EmailTitle, body);

        //}

        //public static bool ActivateAccount(string email, string name,string url)
        //{
        //    string body = string.Empty;
        //    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/AccountActivationEmailTemplate.html"));
        //    body = reader.ReadToEnd();
        //    body = body.Replace("@name", name);
        //    body = body.Replace("@email", email);
        //    body = body.Replace("@url", url);
        //    body = body.Replace("@date", Convert.ToString(Helper.getDateTime()));
        //   return SendEmail.SendMail(email, "Account Activation", body);

        //}

        //public static bool ForgotPassword(string email, string name, string vCode)
        //{
        //    string body = string.Empty;
        //    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/ForgotPasswordEmailTemplate.html"));
        //    body = reader.ReadToEnd();
        //    body = body.Replace("@name", name);
        //    body = body.Replace("@email", email);
        //    body = body.Replace("@vCode", vCode);
        //    body = body.Replace("@date", Convert.ToString(Helper.getDateTime()));
        //   return SendEmail.SendMail(email, "Forgot Password", body);

        //}





    }
}