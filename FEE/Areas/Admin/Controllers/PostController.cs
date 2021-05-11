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

        public ActionResult Index()
        {
            var result = _db.Posts.Where(x=>x.Deleted == false).Select(x => new PostViewModel()
            {
                PostId = x.PostId,
                Name = x.Name,
                Img = x.Img,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                IsShow = x.IsShow,
                Status = x.Status,
                CreateDate = x.CreateDate,
            }).OrderBy(x => x.CreateDate).ToList();
            ViewBag.TrashCount = _db.Posts.Where(x => x.Deleted == true).Count();
            return View(result);
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
        [HttpGet]
        public ActionResult Create()
        {
            var model = new PostViewModel()
            {
                ListCategories = Helper.ListCategories().ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Post();
                    model.Name = viewModel.Name;
                    model.CategoryId = Convert.ToInt32(viewModel.CategoryId);
                    model.Status = viewModel.Status;
                    model.MenuId = viewModel.MenuId;
                    model.Description = viewModel.Description;
                    model.Content = viewModel.Content;
                    model.Deleted = false;
                    model.CreateBy = 1;
                    model.HomeFlag = viewModel.HomeFlag;
                    model.HotFlag = viewModel.HotFlag;
                    model.IsShow = viewModel.IsShow;
                    model.CreateDate = DateTime.Now;
                    model.DepartmentId = 0;
                    model.Alias = XString.ToAscii(model.Name);
                    model.Img = viewModel.Img;
                    model.MoreImgs = viewModel.MoreImgs;
                    _db.Posts.Add(model);
                    _db.SaveChanges();
                    Notification.set_flash("Lưu thành công!", "success");
                    ModelState.Clear();                  
                }
                else
                {
                    Notification.set_flash("Nhập đầy đủ thông tin!", "warning");
                }
                viewModel = new PostViewModel();
                viewModel.ListCategories = Helper.ListCategories().ToList();
                return View(viewModel);
            }
            catch
            {
                Notification.set_flash("Thêm thất bại!", "warning");
                throw;
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _db.Posts.Where(x => x.PostId == id).Select(x => new PostViewModel()
            {
                PostId = x.PostId,
                MenuId = x.MenuId,
                Name = x.Name,
                Description = x.Description,
                CategoryId = x.CategoryId.ToString(),
                Status = x.Status,
                Img = x.Img,
                Content = x.Content,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                IsShow = x.IsShow
            }).SingleOrDefault();
            ViewBag.Img = model.Img;
            model.ListCategories = Helper.ListCategories().ToList();
            ViewBag.UpdateOption = DropdownEdit(0, model.MenuId);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(PostViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _db.Posts.Find(viewModel.PostId);
                    model.Name = viewModel.Name;
                    model.CategoryId = Convert.ToInt32(viewModel.CategoryId);
                    model.Status = viewModel.Status;
                    model.MenuId = viewModel.MenuId;
                    model.Description = viewModel.Description;
                    model.Content = viewModel.Content;
                    model.Deleted = false;
                    model.CreateBy = 1;
                    model.HomeFlag = viewModel.HomeFlag;
                    model.HotFlag = false;
                    model.IsShow = viewModel.IsShow;
                    model.UpdateDate = DateTime.Now;
                    model.UpdateBy = 1;
                    model.DepartmentId = 0;
                    model.Alias = XString.ToAscii(model.Name);
                    model.Img = viewModel.Img;
                    model.MoreImgs = viewModel.MoreImgs;
                    _db.SaveChanges();
                    Notification.set_flash("Lưu thành công!", "success");
                    ModelState.Clear();
                }
                else
                {
                    Notification.set_flash("Nhập đầy đủ thông tin!", "warning");
                }
                viewModel = new PostViewModel();
                viewModel.ListCategories = Helper.ListCategories().ToList();
                return View(viewModel);
            }
            catch
            {
                Notification.set_flash("Thêm thất bại!", "warning");
                throw;
            }
        }

        public string DropdownEdit(int? parentId, int? _pId, string text = "")
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
                    if (item.Id == _pId)
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

        public ActionResult Delete(int id)
        {
            var model = _db.Posts.Where(x => x.PostId == id).SingleOrDefault();
            _db.Posts.Remove(model);
            _db.SaveChanges();
            Notification.set_flash("Xóa vĩnh viễn!", "success");
            return View("Index");
        }
        public JsonResult Trash(int id, bool status)
        {
            var model = _db.Posts.Where(x => x.PostId == id).SingleOrDefault();
            model.Deleted = status;
            _db.SaveChanges();
            Notification.set_flash("Xóa thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrashIndex()
        {
            var result = _db.Posts.Where(x => x.Deleted == true).Select(x => new PostViewModel()
            {
                PostId = x.PostId,
                Name = x.Name,
                Img = x.Img,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                IsShow = x.IsShow,
                Status = x.Status,
                CreateDate = x.CreateDate,
            }).OrderBy(x => x.CreateDate).ToList();
            return View(result);
        }

        public JsonResult ChangeHome(int id, bool status)
        {
            var model = _db.Posts.Where(x => x.PostId == id).SingleOrDefault();
            model.HomeFlag = status;
            _db.SaveChanges();
            Notification.set_flash("Cập nhật thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeShow(int id, bool status)
        {
            var model = _db.Posts.Where(x => x.PostId == id).SingleOrDefault();
            model.IsShow = status;
            _db.SaveChanges();
            Notification.set_flash("Cập nhật thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeHot(int id, bool status)
        {
            foreach(var item in _db.Posts)
            {
                item.HotFlag = false;               
            }
            var model = _db.Posts.Where(x => x.PostId == id).SingleOrDefault();
            model.HotFlag = status;
            _db.SaveChanges();
            Notification.set_flash("Cập nhật thành công!", "success");
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}