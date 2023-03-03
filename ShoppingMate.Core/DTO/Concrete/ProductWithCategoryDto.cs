using ShoppingMate.Core.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete
{
    public class ProductWithCategoryDto : ProductDto
    {
        public Category Category { get; set; }
    }
}
