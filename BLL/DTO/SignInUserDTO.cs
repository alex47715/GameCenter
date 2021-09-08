using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class SignInUserDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
