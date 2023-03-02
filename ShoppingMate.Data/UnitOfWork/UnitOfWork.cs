using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using ShoppingMate.Core.UnitOfWork;
using ShoppingMate.Data.Context;
using ShoppingMate.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public bool disposed;

        public IGenericRepository<Category> CategoryRepository { get; private set; }
        public IGenericRepository<Product> ProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

            CategoryRepository = new GenericRepository<Category>(dbContext);
            ProductRepository = new GenericRepository<Product>(dbContext);
        }


        public void Commit()
        {
            using (var dbContextTransction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransction.Commit();
                }
                catch(Exception ex)
                {
                    // logging
                    dbContextTransction.Rollback();
                }
            }
        }

        public async Task CommitAsync()
        {
            using (var dbContextTransction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    await dbContext.SaveChangesAsync();
                    dbContextTransction.Commit();
                }
                catch (Exception ex)
                {
                    // logging
                    dbContextTransction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
