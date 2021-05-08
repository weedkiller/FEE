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
        public static IEnumerable<SelectListItem> ListCategories()
        {
            FEEDbContext db = new FEEDbContext();
            List<SelectListItem> lstSub = db.Categories
                .Select(m =>
                new SelectListItem
                {
                    Text = m.Name,
                    Value = m.CategoryId.ToString()
                }
                ).ToList();
            return lstSub;
        }
    }
}