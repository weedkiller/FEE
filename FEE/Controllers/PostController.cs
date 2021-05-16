﻿using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.Controllers
{
    public class PostController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();
        public ActionResult PostDetail(int id)
        {
            var result = _db.Posts.Where(x => x.PostId == id).Select(x => new PostViewModel()
            {
                Name = x.Name,
                PostId = x.PostId,
                Img = x.Img,
                Description = x.Description,
                Content = x.Content,
                CreateDate = x.CreateDate
            }).SingleOrDefault();
            return View(result);
        }
        public ActionResult Index(int id)
        {
            var listItem = _db.Posts.Where(x => x.MenuId == id).Select(x => new PostViewModel()
            {
                Name = x.Name,
                PostId = x.PostId,
                Img = x.Img,
                Description = x.Description,
                CreateDate = x.CreateDate
            }).OrderBy(x => x.CreateDate).ToList();
            return View(listItem);
        }
        public ActionResult Category()
        {
            var listItem = _db.Categories.Select(x => new CategoryViewModel()
            {
                Name = x.Name,
                CategoryId = x.CategoryId,
            }).ToList();
            return PartialView(listItem);
        }
        public ActionResult PostRelate(int categoryId)
        {
            var listItem = _db.Posts.Select(x => new PostViewModel()
            {
                Name = x.Name,
                PostId = x.PostId,
                Img = x.Img,
                Description = x.Description,
                CreateDate = x.CreateDate
            }).OrderBy(x => x.CreateDate).ToList();
            listItem = listItem.Where(x => x.CategoryId == categoryId.ToString()).ToList();
            return PartialView(listItem);
        }
    }
}