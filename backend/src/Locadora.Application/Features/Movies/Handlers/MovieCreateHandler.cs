using AutoMapper;
using Locadora.Application.Features.Movies.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Movies.Handlers
{
    public class MovieCreateHandler : IRequestHandler<MovieRegisterCommand, Result<Exception, Guid>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public MovieCreateHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Guid>> Handle(MovieRegisterCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<MovieRegisterCommand, Movie>(request);

            var findGenreCallback = await _genreRepository.GetById(movie.GenreId);
            if (findGenreCallback.IsFailure)
                return findGenreCallback.Failure;

            movie.SetGenre(findGenreCallback.Success);

            var addMovieCallback = await _movieRepository.AddAsync(movie);

            if (addMovieCallback.IsFailure)
                return addMovieCallback.Failure;

            return addMovieCallback.Success.Id;
        }
    }
}
