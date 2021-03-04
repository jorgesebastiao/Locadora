using Locadora.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Movies
{
    public interface IMovieRepository
    {
        Task<Result<Exception, Movie>> AddAsync(Movie movie);
        Result<Exception, IQueryable<Movie>> GetAll();
        Task<Result<Exception, Movie>> GetById(Guid movieId);
        Task<Result<Exception, Movie>> UpdateAsync(Movie movie);
        Task<Result<Exception, Unit>> UpdateAsync(List<Movie> movies);
    }
}