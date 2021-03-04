using FluentValidation.AspNetCore;
using Locadora.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Locadora.WebApi.Extensions
{
    public static class MvcExtensions
    {
        public static void AddMVC(this IServiceCollection services)
        {
            services.AddMvc()
             //Registro automatico dos validadores do FluentValidation
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppModule>())
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.Formatting = Formatting.None;
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
