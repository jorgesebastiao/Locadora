using AutoMapper;
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
    public class GenreUpdateHandler : IRequestHandler<GenreUpdateCommand, Result<Exception, Unit>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreUpdateHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Unit>> Handle(GenreUpdateCommand request, CancellationToken cancellationToken)
        {
            var findGenreCallback = await _genreRepository.GetById(request.Id);
            if (findGenreCallback.IsFailure)
                return findGenreCallback.Failure;

            var genre = findGenreCallback.Success;
            _mapper.Map(request, genre);

            genre.SetLastModification();

            var updateGenreCallback = await _genreRepository.UpdateAsync(genre);
            if (updateGenreCallback.IsFailure)
                return updateGenreCallback.Failure;

            return Unit.Successful;
        }
    }
}
