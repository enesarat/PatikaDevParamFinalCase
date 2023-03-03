using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ShoppingMate.Core.DTO;
using ShoppingMate.Core.Service;
using ShoppingMate.Core.Model.Abstract;

namespace ShoppingMate.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseModel
    {

        private readonly IGenericService<T> _service;

        public NotFoundFilter(IGenericService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id && x.IsActive == true);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponse<NoContentResponse>.Fail(404, $"{typeof(T).Name}({id}) not found"));

        }
    }
}
