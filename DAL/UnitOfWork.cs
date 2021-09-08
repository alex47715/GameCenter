using GameCenter.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL
{
    public class UnitOfWork : IDisposable
    {
        private Context db = new Context();
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private ProductRepository _productRepository;


        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(db);
                return _orderRepository;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(db);
                return _productRepository;
            }
        }
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
