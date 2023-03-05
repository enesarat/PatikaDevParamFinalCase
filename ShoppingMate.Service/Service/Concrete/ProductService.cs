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
using ShoppingMate.Core.Repository;
using AutoMapper;
using ShoppingMate.Core.DTO;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO.Concrete.Product;

namespace ShoppingMate.Service.Service.Concrete
{
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponse<ProductDto>> AddAsync(ProductCreateDto dto)
        {
            var newEntity = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<ProductDto>(newEntity);
            return CustomResponse<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<List<ProductsWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var activeProducts = products.Where(x => x.IsActive == true).ToList();

            var productsDto = _mapper.Map<List<ProductsWithCategoryDto>>(activeProducts);
            return CustomResponse<List<ProductsWithCategoryDto>>.Success(StatusCodes.Status200OK, productsDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(ProductUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.Id = id;

            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }
    }
}

