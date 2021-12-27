using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.WebApi.Extensions
{
    public static class HealthChecksExtensions
    {

        public static IServiceCollection AddHealthChecksMiddleware<T>(this IServiceCollection service) where T : DbContext
        {
            service.AddHealthChecks()
               .AddDbContextCheck<T>();

            return service;
        }

        public static IApplicationBuilder UseHealthyChecksMiddleware(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {

                // The default value is false.
                AllowCachingResponses = false
            });

            return app;
        }

    }
}
