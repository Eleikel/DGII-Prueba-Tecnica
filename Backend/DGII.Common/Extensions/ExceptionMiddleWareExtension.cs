using DGII.Common.Middlewares;
using Microsoft.AspNetCore.Builder;


namespace DGII.Common.Extensions
{
    public static class ExceptionMiddleWareExtension
    {

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
