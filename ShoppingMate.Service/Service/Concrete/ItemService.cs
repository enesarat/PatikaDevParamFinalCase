using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Item;
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
    public class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IGenericRepository<Item> repository, IUnitOfWork unitOfWork, IMapper mapper, IItemRepository itemRepository) : base(repository, unitOfWork, mapper)
        {
            _itemRepository = itemRepository;
        }

        public async Task<CustomResponse<ItemDto>> AddAsync(ItemCreateDto dto)
        {
            var newEntity = _mapper.Map<Item>(dto);

            await _itemRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<ItemDto>(newEntity);
            return CustomResponse<ItemDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(ItemUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Item>(dto);
            entity.Id = id;

            _itemRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }
        public async Task<CustomResponse<NoContentResponse>> DeleteAsync(int id)
        {
            var entity = await _itemRepository.GetByIdAsync(id);

            _itemRepository.Delete(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }
    }
}
