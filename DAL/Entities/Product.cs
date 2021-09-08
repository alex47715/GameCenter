using GameCenter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public GameGenres Genre { get; set; }
        public float? Price { get; set; }
        public string Logo { get; set; }
        public int? CountProducts { get; set; }
        public double? GameRating { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
