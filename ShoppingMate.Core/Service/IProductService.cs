using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Service
{
    public interface IProductService : IGenericService<Product, ProductDto>
    {
        Task<CustomResponse<List<ProductsWithCategoryDto>>> GetProductsWithCategory();

        Task<CustomResponse<NoContentResponse>> UpdateAsync(ProductUpdateDto dto, int id);
        Task<CustomResponse<ProductDto>> AddAsync(ProductCreateDto dto);
    }
}
