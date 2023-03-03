using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.DTO.Concrete;
using ShoppingMate.Service.Service.Abstract;

namespace ShoppingMate.API.Controllers
{
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
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productAsDto = _mapper.Map<ProductDto>(product);

            return CustomActionResult(CustomResponse<ProductDto>.Success(200,productAsDto));
        }
    }
}
