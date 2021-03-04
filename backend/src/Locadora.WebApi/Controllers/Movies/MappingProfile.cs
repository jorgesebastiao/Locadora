using AutoMapper;
using Locadora.Domain.Features.Movies;
using Locadora.WebApi.Controllers.Movies.ViewModels;

namespace Locadora.WebApi.Controllers.Movies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>();

            CreateMap<Movie, MovieDetailViewModel>();
        }
    }
}
