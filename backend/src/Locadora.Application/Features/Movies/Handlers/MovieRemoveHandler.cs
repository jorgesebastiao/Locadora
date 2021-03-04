using Locadora.Application.Features.Movies.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Movies.Handlers
{
    public class MovieRemoveHandler : IRequestHandler<MovieRemoveCommand, Result<Exception, Unit>>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieRemoveHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<Exception, Core.Results.Unit>> Handle(MovieRemoveCommand request, CancellationToken cancellationToken)
        {
            var findMovieCallback = await _movieRepository.GetById(request.MovieId);
            if (findMovieCallback.IsFailure)
                return findMovieCallback.Failure;

            findMovieCallback.Success.SetAsRemoved();

            var updateGenreCallback = await _movieRepository.UpdateAsync(findMovieCallback.Success);
            if (updateGenreCallback.IsFailure)
                return updateGenreCallback.Failure;

            return Unit.Successful;
        }
    }
}
