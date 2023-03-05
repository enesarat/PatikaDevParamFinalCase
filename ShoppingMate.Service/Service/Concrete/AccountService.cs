﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Account;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.DTO.Concrete.Role;
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
    public class AccountService : GenericService<Account, AccountDto>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IGenericRepository<Account> repository, IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository) : base(repository, unitOfWork, mapper)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CustomResponse<AccountDto>> AddCustomerAsync(AccountCreateDto dto)
        {
            var newEntity = _mapper.Map<Account>(dto);
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
            newEntity.RoleId = 1;
            await _accountRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var refObj =_unitOfWork.RoleRepository.Where(x => x.Id == newEntity.RoleId).FirstOrDefault();
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
    }
}
