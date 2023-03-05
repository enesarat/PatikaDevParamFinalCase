using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete.Product;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;

namespace ShoppingMate.API.Controllers
{

    [ValidateFilterAttribute]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product, ProductDto>))]

        public async Task<IActionResult> GetById(int id)
        {
            return CustomActionResult(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _service.GetAllAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CustomActionResult(await _service.GetProductsWithCategory());
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            return CustomActionResult(await _service.AddAsync(productDto));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product, ProductDto>))]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
        {
            return CustomActionResult(await _service.UpdateAsync(productDto, id));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product, ProductDto>))]

        public async Task<IActionResult> Delete(int id)
        {
            return CustomActionResult(await _service.DeleteAsync(id));
        }
    }
}
