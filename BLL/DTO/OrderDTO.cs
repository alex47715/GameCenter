using GameCenter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        [Required]
        public int CountItems { get; set; }
        [Required]
        [EnumDataType(typeof(ParcelStatus))]
        public ParcelStatus Status { get; set; }
        public ProductDTO Product { get; set; }
    }
}
