using Locadora.Core.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Rents
{
    public interface IRentRepository
    {
        Task<Result<Exception, Rent>> AddAsync(Rent rent);
        Result<Exception, IQueryable<Rent>> GetAll();
        Task<Result<Exception, Rent>> GetById(Guid rentId);
    }
}
