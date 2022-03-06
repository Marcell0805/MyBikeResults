using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using MyBikeResults.Infrastructure.Middleware;

namespace MyBikeResults.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/BikeResults/swagger.json", "Bike Results API");
                setupAction.RoutePrefix = "BikeResults";
            });
        }

        public static void ConfigureSwagger(this ILoggerFactory loggerFactory)
        {
            
        }

    }
}
