using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;

namespace ShoppingMate.API.Controllers
{

    [ValidateFilterAttribute]
    [ServiceFilter(typeof(NotFoundFilter<Product>))]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(x=>x.IsActive==true && x.Id==id);
            var productAsDto = _mapper.Map<ProductDto>(product);

            return CustomActionResult(CustomResponse<ProductDto>.Success(200, productAsDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productAsDto = _mapper.Map<List<ProductDto>>(products);

            return CustomActionResult(CustomResponse<List<ProductDto>>.Success(200, productAsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _service.AddAsync(product);

            return CustomActionResult(CustomResponse<Product>.Success(201, product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _service.UpdateAsync(product);

            return CustomActionResult(CustomResponse<NoContentResponse>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(x => x.IsActive == true && x.Id == id);
            await _service.DeleteAsync(product);

            return CustomActionResult(CustomResponse<NoContentResponse>.Success(204));
        }
    }
}
