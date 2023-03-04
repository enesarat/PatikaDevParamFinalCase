using ShoppingMate.Core.DTO.Abstract;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete.Product
{
    public class ProductsWithCategoryDto : BaseDto
    {
        public CategoryDto Category { get; set; }
    }
}
