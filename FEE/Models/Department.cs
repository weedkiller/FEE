using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    public class Department
    {
        [Key]
        [StringLength(128)]
        public string DepartmentId { get; set; }

        public string Name { get; set; }
    }
}