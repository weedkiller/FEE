using FEE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.ViewModel
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string CategoryId { get; set; }
        public string MenuId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public bool IsShow { get; set; }
        public string Img { get; set; }
        public PostStatus Status { get; set; }
        public string MoreImgs { get; set; }
        public string DepartmentId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<SelectListItem> ListCategories { get; set; }
    }
}