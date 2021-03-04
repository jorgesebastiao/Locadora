using AutoMapper;
using Locadora.Application.Features.Genres.Commands;
using Locadora.Application.Features.Movies.Commands;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;

namespace Locadora.Application.Features.Movies
{
    public  class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieRegisterCommand, Movie>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsRemoved, opt => opt.Ignore());

            CreateMap<MovieUpdateCommand, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsRemoved, opt => opt.Ignore());
        }
    }
}
