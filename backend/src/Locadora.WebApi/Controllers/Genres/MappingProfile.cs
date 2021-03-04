using AutoMapper;
using Locadora.Domain.Features.Genres;
using Locadora.WebApi.Controllers.Genres.ViewModels;

namespace Locadora.WebApi.Controllers.Genres
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreViewModel>();

            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}
