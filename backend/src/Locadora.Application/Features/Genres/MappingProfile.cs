using AutoMapper;
using Locadora.Application.Features.Genres.Commands;
using Locadora.Domain.Features.Genres;

namespace Locadora.Application.Features.Genres
{
    public  class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreRegisterCommand, Genre>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsRemoved, opt => opt.Ignore());

            CreateMap<GenreUpdateCommand, Genre>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsRemoved, opt => opt.Ignore());
        }
    }
}
