using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL.Entities;
using GameCenter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
