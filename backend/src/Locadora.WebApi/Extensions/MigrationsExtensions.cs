using Locadora.Infra.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.WebApi.Extensions
{
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var locadoraDbContext = scope.ServiceProvider.GetRequiredService<LocadoraDbContext>();
                locadoraDbContext.Database.Migrate();
            }
        }
    }
}
