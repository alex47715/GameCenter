using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
