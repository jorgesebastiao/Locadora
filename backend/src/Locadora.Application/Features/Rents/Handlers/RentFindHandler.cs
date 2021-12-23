using Locadora.Application.Features.Rents.Queries;
using Locadora.Core.Results;
using Locadora.Domain.Features.Rents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents.Handlers
{
    public class RentFindHandler : IRequestHandler<RentGetQuery, Result<Exception, Rent>>
    {
        private readonly IRentRepository _rentRepository;

        public RentFindHandler(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<Result<Exception, Rent>> Handle(RentGetQuery request, CancellationToken cancellationToken)
        {
            return await _rentRepository.GetById(request.RentId);
        }
    }
}
