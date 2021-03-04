using AutoMapper;
using Locadora.Application.Features.Genres.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Genres.Handlers
{
    public class GenreCreateHandler : IRequestHandler<GenreRegisterCommand, Result<Exception, Guid>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreCreateHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Guid>> Handle(GenreRegisterCommand request, CancellationToken cancellationToken)
        {
            var genre = Mapper.Map<GenreRegisterCommand, Genre>(request);

            var addGenreCallback = await _genreRepository.AddAsync(genre);

            if (addGenreCallback.IsFailure)
                return addGenreCallback.Failure;

            return addGenreCallback.Success.Id;
        }
    }
}
