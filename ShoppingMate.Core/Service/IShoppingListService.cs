using ShoppingMate.Core.DTO.Concrete.Item;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.DTO.Concrete.ShoppingList;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingMate.Core.DTO.Concrete.Account;

namespace ShoppingMate.Core.Service
{
    public interface IShoppingListService : IGenericService<ShoppingList, ShoppingListDto>
    {
        Task<CustomResponse<NoContentResponse>> UpdateAsync(ShoppingListUpdateDto dto, int id);
        Task<CustomResponse<ShoppingListDto>> AddAsync(ShoppingListCreateDto dto);
        Task<CustomResponse<NoContentResponse>> DeleteAsync(int id);
        Task<AccountDto> GetCurrentAccount();

    }
}
