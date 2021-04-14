﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    [Table("CommandInFunctions")]
    public class CommandInFunction
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string CommandId { get; set; }
        [Key]
        [Column(Order = 2)]
        [StringLength(128)]
        public string FunctionId { get; set; }
    }
}