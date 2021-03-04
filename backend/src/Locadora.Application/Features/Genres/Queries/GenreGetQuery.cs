using FluentValidation;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;

namespace Locadora.Application.Features.Genres.Queries
{
    public  class GenreGetQuery : IRequest<Result<Exception, Genre>>
    {
        public Guid GenreId { get; set; }
    }

    public class GenreGetQueryValidator : AbstractValidator<GenreGetQuery>
    {
        public GenreGetQueryValidator()
        {
            RuleFor(x => x.GenreId)
                .NotNull()
                .NotEmpty();
        }
    }
}
