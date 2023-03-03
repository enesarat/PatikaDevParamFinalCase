using Microsoft.EntityFrameworkCore;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(x=> x.Category).ToListAsync();
        }
    }
}
