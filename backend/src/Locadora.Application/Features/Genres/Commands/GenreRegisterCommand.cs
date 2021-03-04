using FluentValidation;
using Locadora.Application.Behaviours;
using System;

namespace Locadora.Application.Features.Genres.Commands
{
    public class GenreRegisterCommand : IRequestWithResult<Guid>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class GenreRegisterCommandValidator : AbstractValidator<GenreRegisterCommand>
    {
        public GenreRegisterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
