using Locadora.Application.Features.Genres.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Genres.Handlers
{
    public class GenreRemoveHandler : IRequestHandler<GenreRemoveCommand, Result<Exception, Unit>>
    {
        private readonly IGenreRepository _genreRepository;

        public GenreRemoveHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Result<Exception, Core.Results.Unit>> Handle(GenreRemoveCommand request, CancellationToken cancellationToken)
        {
            var findGenreCallback = await _genreRepository.GetById(request.GenreId);
            if (findGenreCallback.IsFailure)
                return findGenreCallback.Failure;

            findGenreCallback.Success.SetAsRemoved();

            var updateGenreCallback = await _genreRepository.UpdateAsync(findGenreCallback.Success);
            if (updateGenreCallback.IsFailure)
                return updateGenreCallback.Failure;

            return Unit.Successful;
        }
    }
}
