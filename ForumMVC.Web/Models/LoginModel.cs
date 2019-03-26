using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public class LoginModel
    {
      //  [Required]
        public string /*Email*/Name { get; set; }
       // [Required]
      //  [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}