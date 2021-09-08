using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
