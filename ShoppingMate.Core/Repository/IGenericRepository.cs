using System.Linq.Expressions;

namespace ShoppingMate.Core.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);
    }
}
