using Microsoft.AspNetCore.Diagnostics;
using ShoppingMate.Core.DTO;
using System.Net;
using System.Text.Json;

namespace ShoppingMate.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.StatusCode = statusCode;


                    var response = CustomResponse<NoContentResponse>.Fail(statusCode, exceptionFeature.Error.Message);


                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
