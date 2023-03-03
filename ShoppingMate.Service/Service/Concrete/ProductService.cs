using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.UnitOfWork;
using ShoppingMate.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddAsync(Product item)
        {
            item.CreateDate = DateTime.Now;
            item.CreatedBy = "SystemUser";
            await _unitOfWork.ProductRepository.AddAsync(item);
            await _unitOfWork.CommitAsync();

            return item;
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            var status = await _unitOfWork.ProductRepository.AnyAsync(expression);

            return status;
        }

        public async Task DeleteAsync(Product item)
        {
            _unitOfWork.ProductRepository.Delete(item);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var itemList = await _unitOfWork.ProductRepository.GetAllAsync();

            return itemList;
        }

        public Task<Product> GetByIdAsync(Expression<Func<Product, bool>> expression)
        {
            var item = _unitOfWork.ProductRepository.GetByIdAsync(expression);

            return item;
        }

        public async Task UpdateAsync(Product item)
        {
            item.UpdateDate = DateTime.Now;
            _unitOfWork.ProductRepository.Update(item);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            var result = _unitOfWork.ProductRepository.Where(expression);

            return result;
        }
    }
}
