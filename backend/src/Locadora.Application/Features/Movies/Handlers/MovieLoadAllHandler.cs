using Locadora.Application.Features.Movies.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Movies.Handlers
{
    public class MovieLoadAllHandler : IRequestHandler<MovieLoadAllQuery, Result<Exception, IQueryable<Movie>>>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieLoadAllHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<Exception, IQueryable<Movie>>> Handle(MovieLoadAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_movieRepository.GetAll());
        }
    }
}
