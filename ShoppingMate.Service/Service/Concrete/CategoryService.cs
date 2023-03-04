using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Service.Concrete
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository pcategoryRepository) : base(repository, unitOfWork, mapper)
        {
            _categoryRepository = pcategoryRepository;
        }

        public async Task<CustomResponse<CategoryDto>> AddAsync(CategoryCreateDto dto)
        {
            var newEntity = _mapper.Map<Category>(dto);

            await _categoryRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<CategoryDto>(newEntity);
            return CustomResponse<CategoryDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(CategoryUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Category>(dto);
            entity.Id = id;
            if (await _categoryRepository.AnyAsync(x => x.Id == id && x.IsActive == true))
            {
                _categoryRepository.Update(entity);
                await _unitOfWork.CommitAsync();
                return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
            }
            return CustomResponse<NoContentResponse>.Fail(StatusCodes.Status404NotFound, $" {typeof(Category)} ({id}) not found. Updete operation is not successfull. ");
        }
    }
}
