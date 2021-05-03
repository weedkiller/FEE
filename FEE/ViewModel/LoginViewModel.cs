﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEE.ViewModel
{
    public class LoginViewModel
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Chưa nhập username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Chưa nhập password")]
        [MaxLength(20)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}