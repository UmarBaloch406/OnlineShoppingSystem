using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoping.FileUploader
{
    public class Uploader: Controller
    {
        public string ImageUploader(HttpPostedFileBase file)
        {
            string ext=Path.GetExtension(file.FileName);
            string filename = "Online_Shopping" + DateTime.Now.ToString("yyyyMMddhhmmss")+Guid.NewGuid() + ext;
            string path = "~/fileimage/" + filename;
            string targetpath=Server.MapPath(path);
            file.SaveAs(targetpath);
            string domainnam=HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            return domainnam + "/fileimage/" + filename;
        }
    }
}