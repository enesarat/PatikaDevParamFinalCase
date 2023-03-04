using ShoppingMate.Core.DTO;
using ShoppingMate.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface IGenericService<Entity, Dto> where Entity : BaseModel where Dto : class
    {
        Task<CustomResponse<Dto>> GetByIdAsync(int id);
        Task<CustomResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<CustomResponse<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponse<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
        Task<CustomResponse<Dto>> AddAsync(Dto item);
        Task<CustomResponse<NoContentResponse>> UpdateAsync(Dto item, int id);
        Task<CustomResponse<NoContentResponse>> DeleteAsync(int id);
    }
}
