using Locadora.Core.Results;
using Locadora.Domain.Features.Rents;
using MediatR;
using System;
using System.Linq;

namespace Locadora.Application.Features.Rents.Queries
{
    public class RentLoadAllQuery: IRequest<Result<Exception, IQueryable<Rent>>>
    {

    }
}
