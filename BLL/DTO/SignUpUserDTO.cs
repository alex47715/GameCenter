using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class SignUpUserDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string Name { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string SurName { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required, StringLength(150, MinimumLength = 5)]
        public string AddressDelivery { get; set; }
        [Required, StringLength(32, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
