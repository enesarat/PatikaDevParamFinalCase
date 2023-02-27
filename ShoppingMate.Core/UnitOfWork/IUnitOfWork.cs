﻿using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        Task CommitAsync();
        void Commit();
    }
}
