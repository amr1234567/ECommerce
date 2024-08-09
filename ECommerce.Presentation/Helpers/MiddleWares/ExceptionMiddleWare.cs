using ECommerce.Repositry.Models.OutputModels.Base;
using Newtonsoft.Json;
using System.Net;


namespace ECommerce.Presentation.Helpers.MiddleWare
{
    public class ExceptionMiddleWare(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new CustomResponseModel<string>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = exception.Message,
                Body = exception.Source ?? ""
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
