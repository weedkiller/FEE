using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    [Table("Contacts")]
    public class Contact 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "NVARCHAR")]
        public string ReplyId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}