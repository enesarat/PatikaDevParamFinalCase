using System.Linq.Expressions;

namespace ShoppingMate.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
