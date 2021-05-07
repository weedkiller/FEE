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
    [Authorize]
    public class MenuController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();
        private string htmlOption;
        public MenuController()
        {
            htmlOption = this.DropdownAdd(0);
            ViewBag.htmlOption = htmlOption;
        }

        public ActionResult Index()
        {
            var result = _db.Menus.Select(x => new MenuViewModel()
            {
                Id = x.MenuId,
                Name = x.Name,
                Status = x.Status,
                CreatedDate = x.CreateDate

            }).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var model = new Menu();
                model.Name = viewmodel.Name;
                model.ParentId = viewmodel.ParentId;
                model.Status = viewmodel.Status;
                model.CreateDate = DateTime.Now;
                _db.Menus.Add(model);
                _db.SaveChanges();
            }
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

            foreach(var item in list)
            {
                if(item.ParentId == parentId)
                {
                    htmlOption = htmlOption + "<option value=" + item.Id + ">" + text + item.Name + "</option>";
                    this.DropdownAdd(item.Id, text + "--");
                }
            }
            return htmlOption;
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _db.Menus.Where(x => x.MenuId == id).SingleOrDefault();
            ViewBag.htmlOption = DropdownEdit(0, model.ParentId);
            var viewModel = new MenuViewModel();
            viewModel.Id = model.MenuId;
            viewModel.Name = model.Name;
            viewModel.ParentId = model.ParentId;
            viewModel.Status = model.Status;

            return View(viewModel);
        }
        public string DropdownEdit(int? parentId,int? _pId, string text = "")
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
                    if(item.Id == _pId)
                    {
                        htmlOption = htmlOption + "<option selected value=" + item.Id + ">" + text + item.Name + "</option>";
                        
                    }
                    else
                    {
                        htmlOption = htmlOption + "<option value=" + item.Id + ">" + text + item.Name + "</option>";
                    }
                    this.DropdownEdit(item.Id, _pId, text + "--");
                }
            }
            return htmlOption;
        }
    }
}