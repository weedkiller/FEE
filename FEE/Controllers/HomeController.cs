﻿using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.Controllers
{
    public class HomeController : Controller
    {
        private FEEDbContext _db = new FEEDbContext();
        public ActionResult Index()
        {
            var listResult = new HomeViewModel();

            listResult.ThongBaos = _db.Posts.Where(x => x.CategoryId == 1)
                                            .Select(x => new PostViewModel()
                                            {
                                                PostId = x.PostId,
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x => x.CreateDate).ToList();
            listResult.TinNoiBats = _db.Posts.Where(x => x.Deleted == false && x.IsShow == true && x.HomeFlag == true && x.HotFlag == false)
                                            .Select(x => new PostViewModel()
                                            {
                                                PostId = x.PostId,
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x => x.CreateDate).ToList();
            listResult.TinTucs = _db.Posts.Where(x => x.Deleted == false && x.CategoryId == 1 && x.IsShow == true)
                                            .Select(x => new PostViewModel()
                                            {
                                                PostId = x.PostId,
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x => x.CreateDate).ToList();
            listResult.TinTuyenDung = _db.Posts.Where(x => x.Deleted == false && x.CategoryId == 4 && x.IsShow == true)
                                            .Select(x => new PostViewModel()
                                            {
                                                PostId = x.PostId,
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).OrderBy(x => x.CreateDate).ToList();
            listResult.BaiGhim = _db.Posts.Where(x => x.HotFlag == true && x.Deleted == false && x.IsShow == true)
                                            .Select(x => new PostViewModel()
                                            {
                                                PostId = x.PostId,
                                                Name = x.Name,
                                                Description = x.Description,
                                                Img = x.Img,
                                                CreateDate = x.CreateDate
                                            }).FirstOrDefault();
            listResult.Slides = _db.Slides.Where(x => x.Deleted == false && x.Status == true)
                                            .Select(x => new SlideViewModel()
                                            {
                                                Img = x.Img
                                            }).ToList();
            return View(listResult);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult Menu()
        {
            try
            {
                var result = _db.Menus.Select(x => new MenuViewModel()
                {
                    Id = x.MenuId,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    DisplayOrder = x.DisplayOrder
                    
                }).ToList();

                List<MenuViewModel> listResult = new List<MenuViewModel>();

                foreach (var item in result)
                {
                    if (item.ParentId == 0)
                    {
                        foreach (var menu in result)
                        {
                            if (menu.ParentId == item.Id)
                            {
                                item.SubItem.Add(menu);
                            }

                        }
                        listResult.Add(item);
                    }
                    else
                    {
                        foreach (var sub in result)
                        {
                            if (sub.ParentId == item.Id)
                            {
                                item.SubItem.Add(sub);
                            }
                        }
                    }
                }
                var listMenu = listResult.ToList().OrderBy(x => x.DisplayOrder).ToList();
                return PartialView(listMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }        

    }
}