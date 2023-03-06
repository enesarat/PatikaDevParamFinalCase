using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Role;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Model.Token;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingMate.API.Controllers
{
    [ValidateFilterAttribute]
    public class AccountController : CustomBaseController
    {
        private readonly IAccountService _service;
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("connect/token")]
        public async Task<IActionResult> Login([FromBody] TokenRequest userLogin)
        {
            return Ok(await _service.Login(userLogin));
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromQuery] string token)
        {
            return Ok(await _service.RefreshToken(token));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentAccount()
        {
            return CustomActionResult(CustomResponse<AccountDto>.Success(StatusCodes.Status200OK, await _service.GetCurrentAccount()));
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
