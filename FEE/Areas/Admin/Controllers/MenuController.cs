using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}