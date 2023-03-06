using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.DTO.Concrete.Token;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface IAccountService : IGenericService<Account, AccountDto>
    {
        Task<CustomResponse<NoContentResponse>> UpdateAsync(AccountUpdateDto dto, int id);
        Task<CustomResponse<AccountDto>> AddCustomerAsync(AccountCreateDto dto);
        Task<CustomResponse<AccountDto>> AddAdminAsync(AccountCreateDto dto);
        Task<CustomResponse<AccountDto>> GetByIdAsync(int id);
        AccountDto Authenticate(TokenRequest userLogin);
        TokenDto GenerateToken(AccountDto user);
        Task<TokenDto> Login(TokenRequest userLogin);
        Task<TokenDto> RefreshToken(string tokenStr);
        Task<AccountDto> GetCurrentAccount();

    }
}
