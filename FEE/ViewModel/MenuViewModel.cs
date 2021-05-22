﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập tên danh mục")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string URL { get; set; }

        [Required(ErrorMessage = "Chưa chọn thứ tự")]
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public List<SelectListItem> NavItem = new List<SelectListItem>();

        public List<MenuViewModel> SubItem = new List<MenuViewModel>();

    }
}