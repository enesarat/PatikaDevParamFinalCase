using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.Model.Abstract;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Service.Concrete
{
    public class GenericService<Entity, Dto> : IGenericService<Entity, Dto> where Entity : BaseModel where Dto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponse<Dto>> AddAsync(Dto item)
        {
            Entity newEntity = _mapper.Map<Entity>(item);

            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<Dto>(newEntity);
            return CustomResponse<Dto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponse<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var anyEntity = await _repository.AnyAsync(expression);

            return CustomResponse<bool>.Success(StatusCodes.Status200OK, anyEntity);
        }

        public async Task<CustomResponse<NoContentResponse>> DeleteAsync(int id)
        {

            var entity = await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponse<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var entitiesQueryable = entities.ToList().AsQueryable();
            var activeEntities = entitiesQueryable.Where(x=>x.IsActive==true);

            var dtos = _mapper.Map<IEnumerable<Dto>>(activeEntities);
            return CustomResponse<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponse<Dto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<Dto>(entity);

            return CustomResponse<Dto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<CustomResponse<NoContentResponse>> UpdateAsync(Dto item, int id)
        {
            var entity = _mapper.Map<Entity>(item);
            entity.Id = id;
            if (await _repository.AnyAsync(x => x.Id == id && x.IsActive == true)) {
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return CustomResponse<NoContentResponse>.Success(StatusCodes.Status200OK);
            }
            return CustomResponse<NoContentResponse>.Fail(StatusCodes.Status404NotFound,$" {typeof(Entity)} ({id}) not found. Updete operation is not successfull. ");
        }

    public async Task<CustomResponse<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression)
    {
        var entities = await _repository.Where(expression).ToListAsync();
        var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

        return CustomResponse<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtos);
    }
}
}
