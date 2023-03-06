using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.DTO.Concrete.Role;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface IRoleService : IGenericService<Role, RoleDto>
    {
        Task<CustomResponse<NoContentResponse>> UpdateAsync(RoleUpdateDto dto, int id);
        Task<CustomResponse<RoleDto>> AddAsync(RoleCreateDto dto);
        Task<AccountDto> GetCurrentAccount();

    }
}
