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
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        private FEEDbContext _db = new FEEDbContext();

        public ActionResult Index()
        {
            var result = _db.Departments.Select(x => new DepartmentViewModel()
            {
                Id = x.DepartmentId,
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
        public ActionResult Create(DepartmentViewModel viewmodel)
        {
            try
            {
                var model = new Department();

                model.Name = viewmodel.Name;
                _db.Departments.Add(model);
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
            var model = _db.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
            var viewModel = new DepartmentViewModel();
            model.Name = viewModel.Name;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Departments.Where(x => x.DepartmentId == viewModel.Id).SingleOrDefault();
                model.Name = viewModel.Name;
                _db.SaveChanges();
                Notification.set_flash("Cập nhật thành công!", "success");
                return View();
            }
            return View(viewModel);
        }

        public JsonResult Delete(int id)
        {
            var model = _db.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
            _db.Departments.Remove(model);
            _db.SaveChanges();
            Notification.set_flash("Xóa thành công!", "success");
            return Json(true,JsonRequestBehavior.AllowGet);
        }
    }
}