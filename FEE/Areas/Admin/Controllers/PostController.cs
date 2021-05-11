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
            var result = _db.Posts.Select(x => new PostViewModel()
            {
                PostId = x.PostId,
                Name = x.Name,
                Img = x.Img,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                IsShow = x.IsShow,
                Status = x.Status,
                CreateDate = x.CreateDate,
            });
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
        public ActionResult Create(PostViewModel viewModel)
        {
            try
            {
                var model = new Post();
                model.Name = viewModel.Name;
                model.CategoryId = viewModel.CategoryId;
                model.Status = viewModel.Status;
                model.MenuId = viewModel.MenuId;
                model.Description = viewModel.Description;
                model.Content = viewModel.Content;
                model.Deleted = false;
                model.CreateBy = 1;
                model.CreateDate = DateTime.Now;
                model.DepartmentId = "";
                model.Alias = XString.ToAscii(model.Name);
                model.Img = viewModel.Img;
                model.MoreImgs = viewModel.MoreImgs;
                _db.Posts.Add(model);
                _db.SaveChanges();
                Notification.set_flash("Lưu thành công!", "success");
                viewModel = null;
                viewModel.ListCategories = Helper.ListCategories().ToList();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Notification.set_flash("Thêm thất bại!", "warning");
                throw ex;
            }
        }
    }
}