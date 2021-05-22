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
    public class CategoryController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();

        public ActionResult Index()
        {
            var result = _db.Categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel viewmodel)
        {
            try
            {
                var model = new Category();

                model.Name = viewmodel.Name;
                _db.Categories.Add(model);
                _db.SaveChanges();
                Notification.set_flash("Lưu thành công!", "success");
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                Notification.set_flash("Thêm thất bại!", "warning");
                throw ex;
            }
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _db.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            var viewModel = new CategoryViewModel();
            model.Name = viewModel.Name;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Categories.Where(x => x.CategoryId == viewModel.CategoryId).SingleOrDefault();
                model.Name = viewModel.Name;
                _db.SaveChanges();
                Notification.set_flash("Cập nhật thành công!", "success");
                return View();
            }
            return View(viewModel);
        }

        public JsonResult Delete(int id, bool status)
        {
            var model = _db.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            model.Status = status;
            _db.SaveChanges();
            Notification.set_flash("Xóa thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}