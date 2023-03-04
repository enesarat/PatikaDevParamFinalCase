using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.API.Filters;
using ShoppingMate.Core.DTO.Concrete.Category;
using ShoppingMate.Core.DTO.Concrete.ShoppingList;
using ShoppingMate.Core.Model.Concrete;
using ShoppingMate.Core.Service;

namespace ShoppingMate.API.Controllers
{
    [ValidateFilterAttribute]
    public class ShoppingListController : CustomBaseController
    {
        private readonly IShoppingListService _service;

        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<ShoppingList, ShoppingListDto>))]

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
        public async Task<IActionResult> Create(ShoppingListCreateDto shoppingListDto)
        {
            return CustomActionResult(await _service.AddAsync(shoppingListDto));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<ShoppingList, ShoppingListDto>))]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ShoppingListUpdateDto shoppingListDto)
        {
            return CustomActionResult(await _service.UpdateAsync(shoppingListDto, id));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<ShoppingList, ShoppingListDto>))]

        public async Task<IActionResult> Delete(int id)
        {
            return CustomActionResult(await _service.DeleteAsync(id));
        }
    }
}
