using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;
using Locadora.Domain.Features.Rents;
using Locadora.Infra.Data.Contexts;
using Locadora.Infra.Data.Features.Genres;
using Locadora.Infra.Data.Features.Movies;
using Locadora.Infra.Data.Features.Rents;
using Locadora.WebApi.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.WebApi.Extensions
{
    public static  class DependencyInjectionExtensions
    {
        public static void AddDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.LoadSettings<AppSettings>("AppSettings");

            services.AddScoped(context =>
            {
                var options = new DbContextOptionsBuilder<LocadoraDbContext>().UseSqlServer(appSettings.ConnectionString).Options;
                return new LocadoraDbContext(options);
            });

            services.AddDbContext<LocadoraDbContext>();

            //TODO: Com a evolução do sistema deverá ser movido a injeção de dependencias para uma camada Cross Cuttings
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
        }
    }
}
