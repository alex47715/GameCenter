using GameCenter.DAL.Entities;
using GameCenter.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Repository
{
    public interface IUserRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task AddOrder(Guid userID, Guid productID, int count);
        Task Create(T item);
        void UpdateUser(T item);
        Task Delete(Guid id);
    }
    public class UserRepository : IUserRepository<User>
    {
        private readonly Context _db;

        public UserRepository(Context context)
        {
            _db = context;
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _db.Users.Include(x=>x.Cart).ToListAsync();
            if (result == null)
                throw new NullReferenceException("Users not found");
            return result;
        }

        public async Task<User> Get(Guid id)
        {
            var result = await _db.Users.Include(x=>x.Cart).FirstOrDefaultAsync(x=>x.Id==id);

            if (result == null)
                throw new NullReferenceException("User with this id not found");

            return result;
        }

        public async Task Create(User user)
        {
            var result = _db.Users.FirstOrDefault(x=>x.Id==user.Id);

            if (result != null)
                throw new NullReferenceException("User with this id exist");

            await _db.Users.AddAsync(user);

        }

        public void UpdateUser(User user)
        {
            _db.Entry(user).State=EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            User user = await _db.Users.FirstOrDefaultAsync(x=>x.Id==id);

            if (user == null)
                throw new NullReferenceException("User with this id not found");

            _db.Users.Remove(user);
        }

        public async Task AddOrder(Guid userID, Guid productID, int count)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userID);
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == productID);
            Order order = new Order()
            {
                Product = product,
                CountItems = count,
                Status = ParcelStatus.UnPaid,
                User = user
            };
            await _db.Orders.AddAsync(order);
        }
    }
}
