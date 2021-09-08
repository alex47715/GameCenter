using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL;
using GameCenter.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Services
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetOrders();
        Task<List<OrderDTO>> GetUserOrders(Guid userID);
        Task DeleteOrder(Guid orderID);
    }
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IMapper mapper,UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteOrder(Guid orderID)
        {
            await _unitOfWork.Orders.Delete(orderID);
            await _unitOfWork.Save();
        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            var result = await _unitOfWork.Orders.GetOrders();
            return _mapper.Map<List<OrderDTO>>(result);
        }

        public async Task<List<OrderDTO>> GetUserOrders(Guid userID)
        {
            var result = await _unitOfWork.Orders.GetUserOrders(userID);
            return _mapper.Map<List<OrderDTO>>(result);
        }
    }
}
