using AutoMapper;
using Locadora.Domain.Features.Genres;
using Locadora.WebApi.Controllers.Genres.ViewModels;

namespace Locadora.WebApi.Controllers.Genres
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreViewModel>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreateAt))
                .ForMember(dest => dest.LastModification, opt => opt.MapFrom(src => src.UpdateAt));

            CreateMap<Genre, GenreDetailViewModel>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreateAt))
                .ForMember(dest => dest.LastModification, opt => opt.MapFrom(src => src.UpdateAt));
        }
    }
}
