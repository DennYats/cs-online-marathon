using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAuthenticationAuthorization.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email hasn't been set")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password hasn't been set")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
