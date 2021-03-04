using FluentValidation;
using Locadora.Application.Behaviours;
using System;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Movies.Commands
{
    public  class MovieRemoveCommand : IRequestWithResult<Unit>
    {
        public Guid MovieId { get; set; }

    }

    public class MovieRemoveCommandValidator : AbstractValidator<MovieRemoveCommand>
    {
        public MovieRemoveCommandValidator()
        {
            RuleFor(x => x.MovieId)
                .NotNull()
                .NotEmpty();
        }
    }

}
