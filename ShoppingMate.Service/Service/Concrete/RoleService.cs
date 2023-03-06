using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Role;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Service.Concrete
{
    public class RoleService : GenericService<Role, RoleDto>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public RoleService(IGenericRepository<Role> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository, IHttpContextAccessor contextAccessor) : base(repository, unitOfWork, mapper)
        {
            _roleRepository = roleRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<CustomResponse<RoleDto>> AddAsync(RoleCreateDto dto)
        {
            var newEntity = _mapper.Map<Role>(dto);
            var currentAccount = GetCurrentAccount();
            newEntity.CreatedBy = currentAccount.Result.Email;
            await _roleRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<RoleDto>(newEntity);
            return CustomResponse<RoleDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(RoleUpdateDto dto, int id)
        {
            var entity = _mapper.Map<Role>(dto);
            entity.Id = id;

            _roleRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
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
