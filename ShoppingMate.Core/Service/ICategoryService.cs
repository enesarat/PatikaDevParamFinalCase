using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface ICategoryService : IGenericService<Category, CategoryDto>
    {
        Task<CustomResponse<NoContentResponse>> UpdateAsync(CategoryUpdateDto dto, int id);
        Task<CustomResponse<CategoryDto>> AddAsync(CategoryCreateDto dto);
        Task<AccountDto> GetCurrentAccount();

    }
}
