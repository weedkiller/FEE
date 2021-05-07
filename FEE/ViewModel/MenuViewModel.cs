﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public List<SelectListItem> NavItem = new List<SelectListItem>();
    }
}