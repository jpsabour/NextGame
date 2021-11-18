using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game2Play.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}