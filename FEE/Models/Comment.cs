using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FEE.Models
{
    [Table("Comments")]
    public class Comment 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string PostId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ReplyId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string UserName { get; set; }
    }
}