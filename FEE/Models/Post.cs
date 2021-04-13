﻿using FEE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    public class Post
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string PostId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Alias { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string CategoryId { get; set; }
        public string MenuId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public string Img { get; set; }
        public PostStatus Status { get; set; }
        public string MoreImgs { get; set; }
        public string FacultyId { get; set; }
    }
}