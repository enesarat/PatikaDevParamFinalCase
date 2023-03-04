using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Item;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface IItemService : IGenericService<Item, ItemDto>
    {
        Task<CustomResponse<NoContentResponse>> UpdateAsync(ItemUpdateDto dto, int id);
        Task<CustomResponse<ItemDto>> AddAsync(ItemCreateDto dto);
        Task<CustomResponse<NoContentResponse>> DeleteAsync(int id);

    }
}
