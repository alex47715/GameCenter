using GameCenter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.DTO
{
    public class ProductDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.0, 10)]
        public double GameRating { get; set; }
        [EnumDataType(typeof(GameGenres))]
        [Required]
        public GameGenres Genre { get; set; }
        [Range(0.0, float.MaxValue)]
        [Required]
        public float Price { get; set; }
        [Required]
        public int CountProducts { get; set; }
        public string Logo { get; set; }
    }
}
