using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        PriceModel mod = new PriceModel();
        public ActionResult PriceIndex()
        {
            return View();
        }
        public int Save(PriceModel m)
        {
            m.Save(m);
            return 1;
        }
        public ActionResult PricePartial(int Id)
        {
            mod.ProductId=Id; 
            return PartialView("_PricePartial",mod);
        }

        public ActionResult PriceTableShow()
        {
            return PartialView("_PriceTableShow", mod.PriceShow());
        }

        public ActionResult PriceModlShow(int Id)
        {
            return PartialView("_PriceViewModl", mod.PriceShowModel(Id));
        }
    }
}