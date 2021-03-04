using FluentValidation;
using Locadora.Application.Behaviours;
using System;

namespace Locadora.Application.Features.Movies.Commands
{
    public class MovieRegisterCommand : IRequestWithResult<Guid>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid GenreId { get; set; }
    }

    public class MovieRegisterCommandValidator : AbstractValidator<MovieRegisterCommand>
    {
        public MovieRegisterCommandValidator()
        {
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
