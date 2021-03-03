using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.WebApi.Extensions
{
    public static  class AutoMapperExtensions
    {
        public static void AddAutoMapper( this IServiceCollection services)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(Program));
                cfg.AddProfiles(typeof(Application.AppModule));
            });

            services.AddSingleton(Mapper.Instance);
        }
    }
}
