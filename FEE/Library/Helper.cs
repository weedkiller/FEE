using FEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.Library
{
    public static class Helper
    {
        public static IEnumerable<SelectListItem> MenuItem()
        {
            FEEDbContext db = new FEEDbContext();
            List<SelectListItem> lstSub = db.Menus
                .Select(m =>
                new SelectListItem
                {
                    Text = m.Name,
                    Value = m.MenuId.ToString()
                }
                ).ToList();
            return lstSub;
        }
    }
}