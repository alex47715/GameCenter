using GameCenter.DAL.Entities;
using GameCenter.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Repository
{
    public interface IOrderRepository<T> where T : class
    {
        Task<List<T>> GetOrders();
        Task<List<T>> GetUserOrders(Guid userID);
        Task<T> Get(Guid id);
        Task UpdateStatus(Guid id);
        void UpdateOrder(Order order);
        Task Delete(Guid id);
    }
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly Context _db;

        public OrderRepository(Context context)
        {
            _db = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = await _db.Orders.Include(x=>x.Product).ToListAsync();
            if (result == null)
                throw new NullReferenceException("Orders not found");
            return result;
        }
        public async Task<List<Order>> GetUserOrders(Guid userID)
        {
            var result = await _db.Orders.Where(x=>x.UserId==userID).Include(x => x.Product).ToListAsync();
            if (result == null)
                throw new NullReferenceException("Orders not found");
            return result;
        }

        public async Task<Order> Get(Guid id)
        {
            var result = await _db.Orders.FindAsync(id);

            if (result == null)
                throw new NullReferenceException("Order with this id not found");

            return result;
        }

        public async Task UpdateStatus(Guid id)
        {
            var orderForUpdate = await _db.Orders.FindAsync(id);
            switch (orderForUpdate.Status)
            {
                case ParcelStatus.UnPaid:
                    orderForUpdate.Status = ParcelStatus.WaitingSender;
                    break;
                case ParcelStatus.WaitingSender:
                    orderForUpdate.Status = ParcelStatus.OnTheWay;
                    break;
                case ParcelStatus.OnTheWay:
                    orderForUpdate.Status = ParcelStatus.Received;
                    break;
                case ParcelStatus.Received:
                    orderForUpdate.Status = ParcelStatus.Received;
                    break;
                default:
                    break;
            }
            _db.Entry(orderForUpdate).State=EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Order order = await _db.Orders.FindAsync(id);

            if (order == null)
                throw new NullReferenceException("Order with this id not found");

            _db.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
    }
}
