using FluentValidation;
using Locadora.Application.Behaviours;
using Locadora.Core.Results;
using System;
using System.Collections.Generic;

namespace Locadora.Application.Features.Movies.Commands
{
    public class MovieRemoveMultipleCommand:  IRequestWithResult<Unit>
    {
        public List<Guid> MovieIds { get; set; }
    }

    public class MovieRemoveMultipleCommandValidator : AbstractValidator<MovieRemoveMultipleCommand>
    {
        public MovieRemoveMultipleCommandValidator()
        {
            RuleFor(x => x.MovieIds)
                .NotNull()
                .NotEmpty()
                .Custom((list, context) => {
                    if (list.Count > 20)
                    {
                        context.AddFailure("The list must contain 20 items or fewer");
                    }
                }); 
        }
    }
}
