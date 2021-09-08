using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL;
using GameCenter.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(Guid id);
        Task AddOrder(Guid userID, Guid productID, int count);
        Task Create(UserDTO user);
        Task Update(UserDTO user);
        Task Delete(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddOrder(Guid userID, Guid productID, int count)
        {
            await _unitOfWork.Users.AddOrder(userID, productID, count);
            await _unitOfWork.Save();
        }

        public async Task Create(UserDTO user)
        {
            await _unitOfWork.Users.Create(_mapper.Map<User>(user));
            await _unitOfWork.Save();
        }

        public async Task Delete(Guid id)
        {
            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var result = await _unitOfWork.Users.GetAll();
            return _mapper.Map<List<UserDTO>>(result);
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            var result = await _unitOfWork.Users.Get(id);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task Update(UserDTO user)
        {
            _unitOfWork.Users.UpdateUser(_mapper.Map<User>(user));
            await _unitOfWork.Save();
        }
    }
}
