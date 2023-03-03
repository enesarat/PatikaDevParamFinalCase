using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShoppingMate.Service.Service.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
    }
}
