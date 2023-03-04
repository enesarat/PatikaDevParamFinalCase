using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Item;
using ShoppingMate.Core.DTO.Concrete.ShoppingList;
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
    public class ShoppingListService : GenericService<ShoppingList, ShoppingListDto>, IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        public ShoppingListService(IGenericRepository<ShoppingList> repository, IUnitOfWork unitOfWork, IMapper mapper, IShoppingListRepository shoppingListRepository) : base(repository, unitOfWork, mapper)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public async Task<CustomResponse<ShoppingListDto>> AddAsync(ShoppingListCreateDto dto)
        {
            var newEntity = _mapper.Map<ShoppingList>(dto);

            await _shoppingListRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<ShoppingListDto>(newEntity);
            return CustomResponse<ShoppingListDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(ShoppingListUpdateDto dto, int id)
        {
            var entity = _mapper.Map<ShoppingList>(dto);
            entity.Id = id;

            _shoppingListRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }
        public async Task<CustomResponse<NoContentResponse>> DeleteAsync(int id)
        {
            var entity = await _shoppingListRepository.GetByIdAsync(id);

            _shoppingListRepository.Delete(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }
    }
}
