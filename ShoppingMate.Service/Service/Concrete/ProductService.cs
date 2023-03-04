﻿using Microsoft.EntityFrameworkCore;
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
using ShoppingMate.Core.DTO.Concrete;
using AutoMapper;
using ShoppingMate.Core.DTO;
using Microsoft.AspNetCore.Http;

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

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(ProductUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.Id = id;
            if (await _productRepository.AnyAsync(x => x.Id == id && x.IsActive == true))
            {
                _productRepository.Update(entity);
                await _unitOfWork.CommitAsync();
                return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
            }
            return CustomResponse<NoContentResponse>.Fail(StatusCodes.Status404NotFound, $" {typeof(Product)} ({id}) not found. Updete operation is not successfull. ");
        }
    }
}

