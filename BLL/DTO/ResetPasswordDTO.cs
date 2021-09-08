using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
