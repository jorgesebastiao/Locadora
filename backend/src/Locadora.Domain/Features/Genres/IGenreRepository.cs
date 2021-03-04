using Locadora.Core.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Genres
{
    public interface IGenreRepository
    {
        Result<Exception, IQueryable<Genre>> GetAll();
        Task<Result<Exception, Genre>> GetById(Guid genreId);
        Task<Result<Exception, Genre>> AddAsync(Genre genre);
        Task<Result<Exception, Genre>> UpdateAsync(Genre genre);

    }
}
