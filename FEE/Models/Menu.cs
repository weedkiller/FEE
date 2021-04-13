﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    public class Menu
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string MenuId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ParentId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string PostId { get; set; }
        public string FacultyId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreateDate { get; set; }
    }
}