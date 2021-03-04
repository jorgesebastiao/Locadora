using AutoMapper;
using Locadora.Application.Features.Genres.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Genres.Handlers
{
    public class GenreFindHandler : IRequestHandler<GenreGetQuery, Result<Exception, Genre>>
    {
        private readonly IGenreRepository _genreRepository;

        public GenreFindHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Result<Exception, Genre>> Handle(GenreGetQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetById(request.GenreId);
        }
    }
}
