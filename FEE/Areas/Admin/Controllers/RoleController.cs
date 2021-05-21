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
    public class RoleController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();
        // GET: Admin/Role
        public ActionResult Index()
        {
            var result = _db.Roles.Select(x => new RoleViewModel()
            {
                Id = x.RoleId,
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
        public ActionResult Create(RoleViewModel viewmodel)
        {
            try
            {
                var model = new Role();

                model.Name = viewmodel.Name;
                _db.Roles.Add(model);
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
            var model = _db.Roles.Where(x => x.RoleId == id).SingleOrDefault();
            var viewModel = new RoleViewModel();
            model.Name = viewModel.Name;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Roles.Where(x => x.RoleId == viewModel.Id).SingleOrDefault();
                model.Name = viewModel.Name;
                _db.SaveChanges();
                Notification.set_flash("Cập nhật thành công!", "success");
                return View();
            }
            return View(viewModel);
        }

        public JsonResult Delete(int id)
        {
            var model = _db.Roles.Where(x => x.RoleId == id).SingleOrDefault();
            _db.Roles.Remove(model);
            _db.SaveChanges();
            Notification.set_flash("Xóa thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}