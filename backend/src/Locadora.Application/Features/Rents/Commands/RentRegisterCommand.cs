using FluentValidation;
using Locadora.Application.Behaviours;
using System;
using System.Collections.Generic;

namespace Locadora.Application.Features.Rents.Commands
{
    public class RentRegisterCommand : IRequestWithResult<Guid>
    {
        public string CustomerCpf { get; set; }
        public List<Guid> MovieIds { get; set; }
    }

    public class MovieRegisterCommandValidator : AbstractValidator<RentRegisterCommand>
    {
        public MovieRegisterCommandValidator()
        {
            RuleFor(x => x.CustomerCpf)
                .NotNull()
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(x => x.MovieIds)
                 .NotNull()
                 .NotEmpty()
                 .Custom((list, context) => {
                     if (list != null && list.Count > 20)
                     {
                         context.AddFailure("The list must contain 20 items or fewer");
                     }
                 });
        }
    }
}
