using GameCenter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Repository
{
    public interface IProductRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T item);
        void Update(T item);
        Task Delete(Guid id);
    }
    public class ProductRepository:IProductRepository<Product>
    {
        private readonly Context _db;

        public ProductRepository(Context context)
        {
            _db = context;
        }

        public async Task<List<Product>> GetAll()
        {
            var result = await _db.Products.ToListAsync();
            if (result == null)
                throw new NullReferenceException("Products not found");
            return result;
        }

        public async Task<Product> Get(Guid id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(x=>x.Id==id);

            if (result == null)
                throw new NullReferenceException("Product with this id not found");

            return result;
        }

        public async Task Create(Product product)
        {
            var result = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (result != null)
                throw new NullReferenceException("Product with this exist");

            await _db.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            product.DateCreated = DateTime.Now;
            _db.Entry(product).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x=>x.Id==id);

            if (product == null)
                throw new NullReferenceException("Product with this id not found");

            _db.Products.Remove(product);
        }
    }
}
