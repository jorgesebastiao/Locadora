using AutoMapper;
using Locadora.Domain.Features.Movies;
using Locadora.WebApi.Controllers.Movies.ViewModels;

namespace Locadora.WebApi.Controllers.Movies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreateAt))
                .ForMember(dest => dest.LastModification, opt => opt.MapFrom(src => src.UpdateAt))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreateAt))
                .ForMember(dest => dest.LastModification, opt => opt.MapFrom(src => src.UpdateAt))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
