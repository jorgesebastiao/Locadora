using FluentValidation;
using Locadora.Application.Behaviours;
using System;
using Unit = Locadora.Core.Results.Unit;

namespace Locadora.Application.Features.Movies.Commands
{
    public class MovieUpdateCommand : IRequestWithResult<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid GenreId { get; set; }
    }

    public class MovieUpdateCommandValidator : AbstractValidator<MovieUpdateCommand>
    {
        public MovieUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.GenreId)
              .NotNull()
              .NotEmpty();
        }
    }
}
