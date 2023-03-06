using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Data.Repository
{
    public class ProductRepository :  IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Product> _entities;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _entities = _context.Set<Product>();
        }

        public async Task AddAsync(Product entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await _entities.AnyAsync(expression);
        }

        public void Delete(Product entity)
        {
            var column = entity.GetType().GetProperty("IsActive");
            if (column is not null)
            {
                entity.GetType().GetProperty("IsActive").SetValue(entity, false);
            }
            else
            {
                _entities.Remove(entity);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(x=> x.Category).ToListAsync();
        }

        public void Update(Product entity)
        {
            _entities.Update(entity);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _entities.Where(expression);
        }
    }
}
