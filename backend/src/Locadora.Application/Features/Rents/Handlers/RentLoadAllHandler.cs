using Locadora.Application.Features.Rents.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Rents;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents.Handlers
{
    public class RentLoadAllHandler : IRequestHandler<RentLoadAllQuery, Result<Exception, IQueryable<Rent>>>
    {
        private readonly IRentRepository _rentRepository;

        public RentLoadAllHandler(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<Result<Exception, IQueryable<Rent>>> Handle(RentLoadAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_rentRepository.GetAll());
        }
    }
}
