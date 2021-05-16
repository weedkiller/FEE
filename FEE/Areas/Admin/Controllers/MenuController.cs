using FEE.Library;
using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                CreatedDate = x.CreateDate,
                DisplayOrder = x.DisplayOrder
                
            }).ToList().OrderBy(y => y.DisplayOrder).ToList();
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
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Menu();
                    model.Name = viewmodel.Name;
                    model.ParentId = viewmodel.ParentId;
                    model.Status = viewmodel.Status;
                    model.CreateDate = DateTime.Now;
                    model.DisplayOrder = viewmodel.DisplayOrder;
                    _db.Menus.Add(model);
                    _db.SaveChanges();
                    Notification.set_flash("Lưu thành công!", "success");
                    ModelState.Clear();
                }
                else
                {
                    Notification.set_flash("Nhập đầy đủ thông tin!", "warning");
                }
                htmlOption = "";
                htmlOption = this.DropdownAdd(0);
                ViewBag.htmlOption = htmlOption;
                return View();
            }
            catch(Exception ex)
            {
                Notification.set_flash("Thêm thất bại!", "warning");
                throw ex;
            }
        }

        public string DropdownAdd(int? parentId, string text = "")
        {

            var list = _db.Menus.Select(x => new MenuViewModel()
            {
                Id = x.MenuId,
                Name = x.Name,
                ParentId = x.ParentId,
                DisplayOrder = x.DisplayOrder
            }).ToList().OrderBy(y => y.DisplayOrder).ToList();

            foreach (var item in list)
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
            viewModel.DisplayOrder = model.DisplayOrder;
            return View(viewModel);
        }

        public string DropdownEdit(int? parentId,int? _pId, string text = "")
        {

            var list = _db.Menus.Select(x => new MenuViewModel()
            {
                Id = x.MenuId,
                Name = x.Name,
                ParentId = x.ParentId,
                DisplayOrder = x.DisplayOrder
            }).ToList().OrderBy(y => y.DisplayOrder).ToList();

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

        [HttpPost]
        public ActionResult Update(MenuViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Menus.Where(x => x.MenuId == viewModel.Id).SingleOrDefault();
                model.Name = viewModel.Name;
                model.ParentId = viewModel.ParentId;
                model.Status = viewModel.Status;
                model.UpdateDate = DateTime.Now;
                model.DisplayOrder = viewModel.DisplayOrder;
                _db.SaveChanges();
                Notification.set_flash("Cập nhật thành công!", "success");
                htmlOption = "";
                htmlOption = this.DropdownEdit(0, model.ParentId);                
                ViewBag.htmlOption = htmlOption;
                return View();
            }
            return View(viewModel);
        }

        public JsonResult Delete(int id, bool status)
        {
            var model = _db.Menus.Where(x => x.MenuId == id).SingleOrDefault();
            model.Status = status;
            _db.SaveChanges();
            Notification.set_flash("Ẩn thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(int id, bool status)
        {
            var model = _db.Menus.Where(x => x.MenuId == id).SingleOrDefault();
            model.Status = status;
            _db.SaveChanges();
            Notification.set_flash("Cập nhật thành công!", "success");
            return Json(true,JsonRequestBehavior.AllowGet);
        }
    }
}