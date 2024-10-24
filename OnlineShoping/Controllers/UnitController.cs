using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoping.Models;

namespace OnlineShoping.Controllers
{
    public class UnitController : Controller
    {
        UnitModel unit = new UnitModel();
        // GET: Unit
        public ActionResult UnitIndex()
        {
            return View();
        }
        public int Save(UnitModel mod)
        {
            mod.Save(mod);
            return 1;
        }
        public ActionResult Formget()
        {
            return PartialView("_UnitPartial");
        }
        public ActionResult UnitShow()
        {          
            return PartialView("_UnitShow", unit.UNITShow());
        }
        public int Delete(int Id)
        {
            unit.Delete(Id);
            return 1;
        }
        public ActionResult Edit(int Id)
        {
            
            return View("_UnitPartial", unit.Edit(Id));
        }
    }
}