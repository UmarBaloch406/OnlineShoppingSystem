using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class ColorController : Controller
    {
        ColorModel mod = new ColorModel();

        // GET: Color
        public ActionResult ColorIndex()
        {
            return View();
        }
        public ActionResult Save(ColorModel m)
        {
            m.Save(m);
            return View("ColorIndex");
        }
        public ActionResult formget()
        {
            return PartialView("_ColorPartial");
        }
        public ActionResult ColorIndexShow()
        {
            return PartialView("_ColorShow",mod.ColorShow());
        }
        public int Delete(int Id)
        {
            mod.Delete(Id);
            return 1;
        }
        public ActionResult Edit(int Id)
        {
            return View("_ColorPartial", mod.Edit(Id));
        }
    }
}