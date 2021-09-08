using GameCenter.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Cart { get; set; }
    }
}
