namespace ECommerce.Presentation.Helpers.Extensions
{
    public static class CustomMiddleware
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            //app.UseMiddleware<ExceptionMiddleWare>();
            return app;
        }
    }
}
