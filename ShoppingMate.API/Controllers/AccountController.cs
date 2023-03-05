using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Role;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;

namespace ShoppingMate.API.Controllers
{
    [ValidateFilterAttribute]
    public class AccountController : CustomBaseController
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Account, AccountDto>))]

        public async Task<IActionResult> GetById(int id)
        {
            return CustomActionResult(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _service.GetAllAsync());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCustomer(AccountCreateDto roleDto)
        {
            return CustomActionResult(await _service.AddCustomerAsync(roleDto));
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAdmin(AccountCreateDto roleDto)
        {
            return CustomActionResult(await _service.AddAdminAsync(roleDto));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Account, AccountDto>))]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AccountUpdateDto roleDto)
        {
            return CustomActionResult(await _service.UpdateAsync(roleDto, id));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Account, AccountDto>))]

        public async Task<IActionResult> Delete(int id)
        {
            return CustomActionResult(await _service.DeleteAsync(id));
        }
    }
}
