using AutoMapper;
using GameCenter.BLL.DTO;
using GameCenter.DAL;
using GameCenter.DAL.Entities;
using GameCenter.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Services
{
    public interface IProductService
    {
        Task<ProductDTO> SearchGameByNameAsync(string nameOfProduct);
        Task<List<ProductDTO>> GetGames();
        Task DeleteGameAsync(Guid id);
        Task CreateGameAsync(ProductDTO product);
        Task<ProductDTO> GetGameByIdAsync(Guid id);
        Task UpdateGameAsync(ProductDTO product);

    }
    public class ProductService:IProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(UnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateGameAsync(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await _unitOfWork.Products.Create(newProduct);
            await _unitOfWork.Save();
        }

        public async Task DeleteGameAsync(Guid id)
        {
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task<ProductDTO> GetGameByIdAsync(Guid id)
        {
            var product = await _unitOfWork.Products.Get(id);
            
            if (product == null)
                throw new NullReferenceException("Product with this id not found");

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetGames()
        {
            var products = await _unitOfWork.Products.GetAll();
            if (products == null)
                throw new NullReferenceException("Games not found");
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public Task<ProductDTO> SearchGameByNameAsync(string nameOfProduct)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGameAsync(ProductDTO product)
        {
            _unitOfWork.Products.Update(_mapper.Map<Product>(product));
            await _unitOfWork.Save();
        }
    }
}
