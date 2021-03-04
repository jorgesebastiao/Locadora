using Locadora.Application.Features.Genres.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Genres.Handlers
{
    public class GenreLoadAllHandler : IRequestHandler<GenreLoadAllQuery, Result<Exception, IQueryable<Genre>>>
    {
        private readonly IGenreRepository _genreRepository;

        public GenreLoadAllHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Result<Exception, IQueryable<Genre>>> Handle(GenreLoadAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_genreRepository.GetAll());
        }
    }
}
