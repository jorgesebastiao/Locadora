using FluentValidation;
using Locadora.Application.Behaviours;
using Locadora.Core.Results;
using MediatR;
using System;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Genres.Commands
{
    public class GenreUpdateCommand : IRequestWithResult<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class GenreUpdateCommandValidator : AbstractValidator<GenreUpdateCommand>
    {
        public GenreUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
