using AutoMapper;
using Locadora.Application.Features.Movies.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Movies.Handlers
{
    public class MovieUpdateHandler : IRequestHandler<MovieUpdateCommand, Result<Exception, Unit>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public MovieUpdateHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Unit>> Handle(MovieUpdateCommand request, CancellationToken cancellationToken)
        {
            var findMovieCallback = await _movieRepository.GetById(request.Id);
            if (findMovieCallback.IsFailure)
                return findMovieCallback.Failure;

            var movie = findMovieCallback.Success;
            _mapper.Map(request, movie);

            var findGenreCallback = await _genreRepository.GetById(movie.GenreId);
            if (findGenreCallback.IsFailure)
                return findGenreCallback.Failure;

            movie.SetGenre(findGenreCallback.Success);
            movie.SetLastModification();

            var updateGenreCallback = await _movieRepository.UpdateAsync(movie);
            if (updateGenreCallback.IsFailure)
                return updateGenreCallback.Failure;

            return Unit.Successful;
        }
    }
}
