using FEE.Library;
using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();
        private string htmlOption;
        public PostController()
        {
            htmlOption = this.DropdownAdd(0);
            ViewBag.htmlOption = htmlOption;
        }
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }
        public string DropdownAdd(int? parentId, string text = "")
        {

            var list = _db.Menus.Select(x => new MenuViewModel()
            {
                Id = x.MenuId,
                Name = x.Name,
                ParentId = x.ParentId

            }).ToList();

            foreach (var item in list)
            {
                if (item.ParentId == parentId)
                {
                    htmlOption = htmlOption + "<option value=" + item.Id + ">" + text + item.Name + "</option>";
                    this.DropdownAdd(item.Id, text + "--");
                }
            }
            return htmlOption;
        }
        public ActionResult Create()
        {
            var model = new PostViewModel()
            {
                ListCategories = Helper.ListCategories().ToList()
            };
            return View(model);
        }
    }
}