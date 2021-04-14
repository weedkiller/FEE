using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [StringLength(128)]
        public string DepartmentId { get; set; }

        public string Name { get; set; }
    }
}