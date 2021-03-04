using Locadora.Application.Features.Movies.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Movies.Handlers
{
    public  class MovieMultipleRemoveHandler : IRequestHandler<MovieRemoveMultipleCommand, Result<Exception, Unit>>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieMultipleRemoveHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<Exception, Core.Results.Unit>> Handle(MovieRemoveMultipleCommand request, CancellationToken cancellationToken)
        {
            var getAllMovieCallback =  _movieRepository.GetAll();
            if (getAllMovieCallback.IsFailure)
                return getAllMovieCallback.Failure;

            var movies = getAllMovieCallback.Success.Where(x => request.MovieIds.Contains(x.Id)).ToList();

            if (movies.Any())
            {
                movies.ForEach(x => x.SetAsRemoved());

                var updateMoviesCallback = await _movieRepository.UpdateAsync(movies);
                if (updateMoviesCallback.IsFailure)
                    return updateMoviesCallback.Failure;
            }
            return Unit.Successful;
        }
    }
}
