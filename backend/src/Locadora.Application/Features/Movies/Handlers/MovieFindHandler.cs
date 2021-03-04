using Locadora.Application.Features.Movies.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Movies.Handlers
{
    public class MovieFindHandler : IRequestHandler<MovieGetQuery, Result<Exception, Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieFindHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<Exception, Movie>> Handle(MovieGetQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetById(request.MovieId);
        }
    }
}
