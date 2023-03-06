using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.DTO.Concrete.Role;
using ShoppingMate.Core.DTO.Concrete.Token;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Model.Token;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Service.Concrete
{
    public class AccountService : GenericService<Account, AccountDto>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(IGenericRepository<Account> repository, IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository, IConfiguration config, IHttpContextAccessor contextAccessor) : base(repository, unitOfWork, mapper)
        {
            _accountRepository = accountRepository;
            _config = config;
            _contextAccessor = contextAccessor;
        }

        public async Task<CustomResponse<AccountDto>> AddCustomerAsync(AccountCreateDto dto)
        {
            var newEntity = _mapper.Map<Account>(dto);
            var currentAccount = GetCurrentAccount();
            newEntity.CreatedBy = currentAccount.Result.Email;
            newEntity.RoleId = 2;
            await _accountRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var refObj = _unitOfWork.RoleRepository.Where(x => x.Id == newEntity.RoleId).FirstOrDefault();
            var newDto = _mapper.Map<AccountDto>(newEntity);
            newDto.Role = refObj.Name;
            return CustomResponse<AccountDto>.Success(StatusCodes.Status200OK, newDto);
        }
        public async Task<CustomResponse<AccountDto>> AddAdminAsync(AccountCreateDto dto)
        {
            var newEntity = _mapper.Map<Account>(dto);
            var currentAccount = GetCurrentAccount();
            newEntity.CreatedBy = currentAccount.Result.Email;
            newEntity.RoleId = 1;
            await _accountRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var refObj = _unitOfWork.RoleRepository.Where(x => x.Id == newEntity.RoleId).FirstOrDefault();
            var newDto = _mapper.Map<AccountDto>(newEntity);
            newDto.Role = refObj.Name;
            return CustomResponse<AccountDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(AccountUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Account>(dto);
            entity.Id = id;

            _accountRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<AccountDto>> GetByIdAsync(int id)
        {
            var entity = await _accountRepository.GetByIdAsync(id);
            if (entity.IsActive != false)
            {
                var refObj = _unitOfWork.RoleRepository.Where(x => x.Id == entity.RoleId).FirstOrDefault();
                var dto = _mapper.Map<AccountDto>(entity);
                dto.Role = refObj.Name;

                return CustomResponse<AccountDto>.Success(StatusCodes.Status200OK, dto);
            }
            return CustomResponse<AccountDto>.Fail(StatusCodes.Status404NotFound, $" {typeof(Account).Name} ({id}) not found. Retrieve operation is not successfull. ");
        }

        public AccountDto Authenticate(TokenRequest userLogin)
        {
            var currentAccount = _accountRepository.Where(o => o.Email.ToLower() == userLogin.Email.ToLower() && o.Password == userLogin.Password).FirstOrDefault();


            if (currentAccount is not null)
            {
                var refObj = _unitOfWork.RoleRepository.Where(x => x.Id == currentAccount.RoleId).FirstOrDefault();

                var accountDto = _mapper.Map<AccountDto>(currentAccount);
                accountDto.Role = refObj.Name;

                return accountDto;
            }

            return null;
        }

        public TokenDto GenerateToken(AccountDto user)
        {
            TokenDto tokenModel = new TokenDto();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };

            tokenModel.Expiration = DateTime.Now.AddMinutes(5);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: tokenModel.Expiration,
            signingCredentials: credentials);

            tokenModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<TokenDto> RefreshToken(string tokenStr)
        {
            var account = _accountRepository.Where(o => o.RefreshToken == tokenStr).FirstOrDefault();
            if (account is null)
            {
                throw new InvalidOperationException("No account found matching the Refresh token");
            }

            var currentAccount = _accountRepository.Where(o => o.RefreshTokenExpireDate > DateTime.Now).FirstOrDefault();
            var role = _unitOfWork.RoleRepository.Where(x => x.Id == currentAccount.RoleId).FirstOrDefault();
            var accountDto = _mapper.Map<AccountDto>(currentAccount);
            accountDto.Role = role.Name;
            if (currentAccount is not null)
            {
                TokenDto token =  GenerateToken(accountDto);
                currentAccount.RefreshToken = token.RefreshToken;
                currentAccount.RefreshTokenExpireDate = DateTime.Now.AddMinutes(3);
                _accountRepository.Update(currentAccount);
                _unitOfWork.Commit();

                return token;
            }
            else
                throw new InvalidOperationException("No Valid refresh tokens were found.");
        }

        public async Task<TokenDto> Login(TokenRequest userLogin)
        {
            var userDto = Authenticate(userLogin);

            if (userDto != null)
            {
                var user = _accountRepository.Where(x=>x.Id==userDto.Id).FirstOrDefault();
                var token = GenerateToken(userDto);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(3);
                user.UpdateDate = DateTime.Now;
                _accountRepository.Update(user);
                _unitOfWork.Commit();
                return token;
            }
            else
                throw new InvalidOperationException("Email or password is invalid.");
        }

        public async Task<AccountDto> GetCurrentAccount()
        {
            var identity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                AccountDto currentaccount = new AccountDto
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value

                };
                return currentaccount;
            }
            else
                throw new InvalidOperationException("Could not access active user information.");
        }
    }
}
