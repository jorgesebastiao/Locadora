using Microsoft.AspNetCore.Builder;

namespace Locadora.WebApi.Extensions
{
    public static  class CORSExtensions
    {
        public static void UseCORS(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .Build());
        }
    }
}
