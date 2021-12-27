using FluentValidation;
using Locadora.Core.Results;
using Locadora.Domain.Features.Rents;
using MediatR;
using System;

namespace Locadora.Application.Features.Rents.Queries
{
    public  class RentGetQuery : IRequest<Result<Exception, Rent>>
    {
        public Guid RentId { get; set; }
    }

    public class RentGetQueryValidator : AbstractValidator<RentGetQuery>
    {
        public RentGetQueryValidator()
        {
            RuleFor(x => x.RentId)
                .NotNull()
                .NotEmpty();
        }
    }
}
