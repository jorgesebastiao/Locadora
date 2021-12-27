using AutoMapper;
using Locadora.Application.Features.Movies.Commands;
using Locadora.Application.Features.Rents.Commands;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using Locadora.Domain.Features.Rents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents.Handlers
{
    public class RentCreateHandler : IRequestHandler<RentRegisterCommand, Result<Exception, Guid>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public RentCreateHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Guid>> Handle(RentRegisterCommand request, CancellationToken cancellationToken)
        {
           /* var rent = _mapper.Map<RentRegisterCommand, Rent>(request);

            var findGenreCallback = await _movieRepository.GetById(movie.GenreId);
            if (findGenreCallback.IsFailure)
                return findGenreCallback.Failure;


            var addMovieCallback = await _movieRepository.AddAsync(movie);

            if (addMovieCallback.IsFailure)
                return addMovieCallback.Failure;*/

            return Guid.NewGuid();
        }
    }
}
