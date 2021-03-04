using FluentValidation;
using Locadora.Application.Behaviours;
using System;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Genres.Commands
{
    public  class GenreRemoveCommand : IRequestWithResult<Unit>
    {
        public Guid GenreId { get; set; }

    }

    public class GenreRemoveCommandValidator : AbstractValidator<GenreRemoveCommand>
    {
        public GenreRemoveCommandValidator()
        {
            RuleFor(x => x.GenreId)
                .NotNull()
                .NotEmpty();
        }
    }

}
