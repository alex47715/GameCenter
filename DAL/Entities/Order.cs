using GameCenter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int CountItems { get; set; }
        public ParcelStatus Status { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
