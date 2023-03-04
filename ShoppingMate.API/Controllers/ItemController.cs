using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.Item;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;

namespace ShoppingMate.API.Controllers
{
    [ValidateFilterAttribute]
    public class ItemController : CustomBaseController
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Item, ItemDto>))]

        public async Task<IActionResult> GetById(int id)
        {
            return CustomActionResult(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateDto itemDto)
        {
            return CustomActionResult(await _service.AddAsync(itemDto));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Item, ItemDto>))]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ItemUpdateDto itemDto)
        {
            return CustomActionResult(await _service.UpdateAsync(itemDto, id));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Item, ItemDto>))]

        public async Task<IActionResult> Delete(int id)
        {
            return CustomActionResult(await _service.DeleteAsync(id));
        }
    }
}
