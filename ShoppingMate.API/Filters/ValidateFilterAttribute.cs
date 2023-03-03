using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingMate.Core.DTO;

namespace ShoppingMate.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute    
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponse<NoContentResponse>.Fail(400, errors));
            }
        }
    }
}
