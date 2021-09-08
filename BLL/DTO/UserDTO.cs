using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        [Required, StringLength(30, MinimumLength = 6)]
        public string Name { get; set; }
        [Required, StringLength(30, MinimumLength = 6)]
        public string SurName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(150, MinimumLength = 5)]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        public ICollection<OrderDTO> Cart { get; set; }
    }
}
